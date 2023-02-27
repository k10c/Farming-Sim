using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

// Original class by: Ben
// Observer pattern update by: Aidan

public abstract class PlantType : MonoBehaviour, IPointerDownHandler
{
	public ItemSO[] resources;
	public int[] resQuants;
	public Sprite[] growArray;
	[HideInInspector]public SpriteRenderer sprite;
	[HideInInspector]public InventoryManager inventory;

	// for code review: these are currently not private for convenience but could be made so if necessary
	public int timeToGrow;
	public int timeGrown;
    public bool fullyGrown;
	public float growPercent;

    public PlantType(){	}
	
	public abstract PlantType Clone();

	
	public virtual void Awake()
	{
		AddPhysics2DRaycaster();
        sprite = GetComponent<SpriteRenderer>();
		inventory = FindObjectOfType<InventoryManager>();
        sprite.sprite = growArray[0];
        ShowGrowth();
        TimeManager.OnMinuteChanged += UpdateGrowth;
    }
	
	//detects when the plant is clicked
	public void OnPointerDown(PointerEventData eventData)
    {
		Debug.Log(GetDetails());
		if(fullyGrown)
		{
			Harvest();
		}
    }
	
	//determines whether a raycaster has already been created (ensures it is only loaded once)
    private void AddPhysics2DRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }
	
	// method to return if plant is fully grown
	public bool CheckIfGrown()
	{
		return fullyGrown;
	}
	
	// changes the sprite to show how close it is to fully grown
	public void ShowGrowth()
	{
		if(sprite != null)
		{
            sprite.sprite = growArray[(int)((float)(growArray.Length - 1) * growPercent / 100.0f)];
        }
    }

	// called every in game minute
	public void UpdateGrowth()
	{
		timeGrown++;
		if(timeGrown >= timeToGrow)
		{
			fullyGrown= true;
			growPercent = 100.0f;
            // unsubscribe UpdateGrowth from minute changing
            TimeManager.OnMinuteChanged -= UpdateGrowth;
        }
		else
		{
            // calculate the new growth percentage
            growPercent = ((float)timeGrown / (float)timeToGrow) * 100;
        }
		ShowGrowth();
	}
	
	public virtual void Harvest()
	{
		for(int res = 0; res < resources.Length; res++)
		{
			for(int quant = Random.Range(0, resQuants[res]); quant < resQuants[res]; quant++)
			{
				inventory.AddItem(resources[res]);
			}
		}
	}
	
	public abstract string GetDetails();
	
	public float GetCurrGrowth() {return growPercent;}
}