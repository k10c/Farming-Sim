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
		inventory.PassToInv(player.GetComponent<InventoryManager>());
	}

	override public string GetDetails()
	{
		return "HARVEST BOT (EMPTY)";
	}
}