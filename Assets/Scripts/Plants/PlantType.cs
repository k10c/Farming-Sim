using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

// Original class by: Ben
// Observer pattern update by: Aidan

public abstract class PlantType : MonoBehaviour, InteractableType
{
	public ItemSO[] resources;
	public int[] resQuants;
	public InvPacker inventory;
	public Sprite[] growArray;
	[HideInInspector]public SpriteRenderer sprite;

	// for code review: these are currently not private for convenience but could be made so if necessary
	public int timeToGrow;
	public int timeGrown;
    public bool fullyGrown;
	public float growPercent;

    public PlantType(){	}
	
	public abstract PlantType Clone();

	
	public virtual void Awake()
	{
        sprite = GetComponent<SpriteRenderer>();
		inventory = new InvPacker(resources);
        sprite.sprite = growArray[0];
        ShowGrowth();
        TimeManager.OnMinuteChanged += UpdateGrowth;
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
	
	public virtual InvPacker Harvest()
	{
		//sets the ammount of each resource in inventory to a random number based on their respective resQuants
		int[] cropYield = new int[resQuants.Length];
		for(int quant = 0; quant < resQuants.Length; quant++)
		{
			cropYield[quant] = Random.Range(1, resQuants[quant]);
		}
		inventory.SetInvCount(cropYield);
		Debug.Log(inventory.GetDetails());
		//sends inventory to whatever harvested the plant
		return inventory;
	}
	
	public void Interact(GameObject player)
	{
		if(fullyGrown)
			Harvest().PassToInv(player.GetComponent<InventoryManager>());
	}
	
	public abstract string GetDetails();
	
	public float GetCurrGrowth() {return growPercent;}
}