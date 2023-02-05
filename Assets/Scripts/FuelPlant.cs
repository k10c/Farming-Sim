using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPlant : PlantType
{
	FuelPlant()
	{
		setCurrGrowth(0.0f);
		setGrown(100.0f);
		setResource(ResourceType.FUEL);
		setResourceQuantity(5);
	}
	override public void Awake()
	{
		sprite = GetComponent<SpriteRenderer>();
		ShowGrowth();
		Debug.Log(getDetails());
	}
	override public PlantType Clone()
	{
		return (PlantType)this.Clone();
	}
	override public void Harvest()
	{
		//drops flower seeds and fuel
		//destroys plant
	}
	override public string getDetails()
	{
		return "This Fuel Flower is " + (getCurrGrowth() / getGrown() * 100) + "% grown.";
	}
}