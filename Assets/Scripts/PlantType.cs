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
	}
	
	public bool CheckIfGrown()
	{
		return fullyGrown;
	}
	
	public void ShowGrowth()
	{
		sprite.color = new Color(255 * (1 - timeGrown / timeToGrow),255 * (timeGrown / timeToGrow),0); //To be replaced with changing sprite as plant grows
	}
	public void UpdateGrowth()
	{
		timeGrown++;

		if(timeGrown >= timeToGrow)
		{
			fullyGrown= true;
			growPercent = 100.0f;
			// unsubscribe UpdateGrowth from minute changing
		}
		else
		{
            // calculate the new growth percentage
            growPercent = ((float)timeGrown / (float)timeToGrow) * 100;
        }
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