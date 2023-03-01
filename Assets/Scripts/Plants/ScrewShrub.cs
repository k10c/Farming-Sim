using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Written by: Ben

public class ScrewShrub : PlantType
{
	ScrewShrub(){ }

	override public PlantType Clone()
	{
		return (ScrewShrub)this.Clone();
	}

	override public string GetDetails()
	{
		return "This Screw Shrub is " + growPercent.ToString() + "% grown.";
	}
	
	override public InvPacker Harvest()
	{
		InvPacker inv = base.Harvest();
		timeGrown = (int)(timeToGrow * 0.25);
		growPercent = 25.0f;
		fullyGrown = false;
		ShowGrowth();
		TimeManager.OnMinuteChanged += UpdateGrowth;
		return inv;
	}
}