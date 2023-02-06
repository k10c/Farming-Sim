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
	public float currGrowth;
	public float grown;
	public ResourceType resource; //To be replaced with the actual "item" version of the resources
	public int resourceQuantity;
	[HideInInspector]public SpriteRenderer sprite;
	
	public PlantType()
	{
		currGrowth = 0.0f;
		grown = 0.0f;
		resource = ResourceType.NONE;
		resourceQuantity = 0;
	}
	
	public abstract PlantType Clone();
	
	public void Update() //used for testing right now, can be removed once other interaction options available
	{
		
	}
	
	public virtual void Awake()
	{
		sprite = GetComponent<SpriteRenderer>();
	}
	
	public bool checkGrown()
	{
		return currGrowth > grown;
	}
	
	public void ShowGrowth()
	{
		sprite.color = new Color(255 * (1 - currGrowth / grown),255 * (currGrowth / grown),0); //To be replaced with changing sprite as plant grows
	}
	public float Grow(float growth)
	{
		currGrowth += growth;
		ShowGrowth();
		return currGrowth;
	}
	
	public virtual void Harvest()
	{
		/*
		Drops / adds items (resource, resource quantity) to inventory
		Destroys plant / resets progress a certain ammount, depending on plant type
		*/
	}
	
	public abstract string getDetails();
	
	public float getCurrGrowth() {return currGrowth;}
	public float getGrown() {return grown;}
	public ResourceType getResource() {return resource;}
	public int getResourceQuantity() {return resourceQuantity;}
	public void setCurrGrowth(float newGrowth) {currGrowth = newGrowth;}
	public void setGrown(float newGrown) {grown = newGrown;}
	public void setResource(ResourceType newResource) {resource = newResource;}
	public void setResourceQuantity(int newQuantity) {resourceQuantity = newQuantity;}
}