using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPlant : PlantType
{
	// in each plant constructor: set how many minutes it should take to grow fully, its resource, and how much of that resource it provides on harvest
	FuelPlant()
	{
		timeToGrow = 10;
		SetResource(ResourceType.FUEL);
		SetResourceQuantity(5);
	}

	override public PlantType Clone()
	{
		return (FuelPlant)this.Clone();
	}

	override public string GetDetails()
	{
		return "This Fuel Flower is " + growPercent.ToString() + "% grown.";
	}
	
    override public void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        ShowGrowth();
        TimeManager.OnMinuteChanged += UpdateGrowth;
    }
}