using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Written by: Ben

public class FuelPlant : PlantType
{
	FuelPlant(){ }

	override public PlantType Clone()
	{
		return (FuelPlant)this.Clone();
	}

	override public string GetDetails()
	{
		return "This Fuel Flower is " + growPercent.ToString() + "% grown.";
	}
	
	override public InvPacker Harvest()
	{
		InvPacker inv = base.Harvest();
		Destroy(gameObject);
		return inv;
	}
}