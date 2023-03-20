using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Written by: Ben
//HarvestBot is a type of bot that helps the player by gathering the resources from grown plants.
//It wanders around until it finds a grown plant, then harvest them and stores the contents in its own inventory.

public class HarvestBot : RoboType
{
	HarvestBot(){ }

	override public RoboType Clone()
	{
		return (HarvestBot)this.Clone();
	}

	override public void Collect()
	{
		if(target.CheckIfGrown())
		{
			inventory.AddInv(target.Harvest());
			Debug.Log("BOT: " + inventory.GetDetails());
		}
	}
	
	override public void Interact(GameObject player)
	{
		Debug.Log(GetDetails());
		inventory.PassToInv(player.GetComponent<InventoryHolder>());
	}

	override public string GetDetails()
	{
		return "HARVEST BOT (EMPTY)";
	}
}