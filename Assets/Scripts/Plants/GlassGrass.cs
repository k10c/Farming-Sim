using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Written by: Ben

public class GlassGrass : PlantType
{
	GlassGrass(){ }

	override public PlantType Clone()
	{
		return (GlassGrass)this.Clone();
	}

	override public string GetDetails()
	{
		return "This Glass Grass is " + growPercent.ToString() + "% grown.";
	}
	
	override public void Harvest()
	{
		base.Harvest();
		Destroy(gameObject);
	}
}