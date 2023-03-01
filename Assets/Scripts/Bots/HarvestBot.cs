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
			inventory.AddInv(target.Harvest());
			Debug.Log("BOT: " + inventory.GetDetails());
		}
	}
	
	override public void Collect()
	{
		Debug.Log(GetDetails());
		inventory.PassToInv(playerInv);
	}

	override public string GetDetails()
	{
		return "HARVEST BOT (EMPTY)";
	}
}