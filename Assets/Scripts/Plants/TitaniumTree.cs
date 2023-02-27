using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Written by: Ben

public class TitaniumTree : PlantType
{
	TitaniumTree(){ }

	override public PlantType Clone()
	{
		return (TitaniumTree)this.Clone();
	}

	override public string GetDetails()
	{
		return "This Titanium Tree is " + growPercent.ToString() + "% grown.";
	}
	
	override public void Harvest()
	{
		base.Harvest();
		Destroy(gameObject);
	}
}