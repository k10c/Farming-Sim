using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Written by: Ben

public class HarvestBot : RoboType
{
	HarvestBot(){ }

	override public RoboType Clone()
	{
		return (HarvestBot)this.Clone();
	}

	override public void Interact()
	{
		if(target.CheckIfGrown())
		{
			target.Harvest();
		}
	}
	
	override public void Collect()
	{
		
	}

	override public string GetDetails()
	{
		return "HARVEST BOT (EMPTY)";
	}
}