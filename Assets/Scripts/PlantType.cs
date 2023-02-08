using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{
	FUEL,
	TITANIUM,
	SCREWS,
	NONE
}

public abstract class PlantType : MonoBehaviour
{
	public ResourceType resource; //To be replaced with the actual "item" version of the resources
	public int resourceQuantity;
	public Sprite[] growArray;
	[HideInInspector]public SpriteRenderer sprite;

    public int timeToGrow { get; set; }
    public int timeGrown { get; set; }
    public bool fullyGrown;
	public float growPercent;

    public PlantType()
	{
		timeToGrow = 0;
		timeGrown = 0;
		fullyGrown = false;
		growPercent = 0.0f;
		resource = ResourceType.NONE;
		resourceQuantity = 0;
	}
	
	public abstract PlantType Clone();

	
	public virtual void Awake()
	{
		sprite = GetComponent<SpriteRenderer>();
		sprite.sprite = growArray[0];
	}
	
	public bool CheckIfGrown()
	{
		return fullyGrown;
	}
	
	public void ShowGrowth()
	{
		sprite.sprite = growArray[(int)((float)(growArray.Length - 1) * growPercent / 100.0f)];
        Debug.Log(GetDetails());
    }
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
		/*
		Drops / adds items (resource, resource quantity) to inventory
		Destroys plant / resets progress a certain ammount, depending on plant type
		*/
	}
	
	public abstract string GetDetails();
	
	public float GetCurrGrowth() {return growPercent;}

	// resource related methods: get/set resource, get/set quantity

	public ResourceType getResource() {return resource;}
	public int GetResourceQuantity() {return resourceQuantity;}
	public void SetResource(ResourceType newResource) {resource = newResource;}
	public void SetResourceQuantity(int newQuantity) {resourceQuantity = newQuantity;}

}