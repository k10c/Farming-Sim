using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//InvPacker is a way for us to pass inventories between objects without needing each one to have an actual inventory.
//It can convert it's contents to an inventory automatically, but doesn't require you to understand how inventories work.
public class InvPacker : MonoBehaviour
{
    private ItemSO[] invObjects;
	private int[] invCount;
	
	public InvPacker()
	{
		invObjects = Resources.LoadAll<ItemSO>("Items");
		invCount = new int[invObjects.Length];
	}
	
	//sets up the InvPacker with a predetermined array of ItemSOs(if an object only needs to hold certain types of objects)
	public InvPacker(ItemSO[] invArray)
	{
		invObjects = invArray;
		invCount = new int[invObjects.Length];
	}
	
	//sets up the InvPacker with a predetermined array of ItemSOs and counts (if it already has a set number of certain resource types)
	public InvPacker(ItemSO[] invArray, int[] invCountArray)
	{
		invObjects = invArray;
		if(invArray.Length != invCountArray.Length)
		{
			Debug.Log("InvPacker: Incompatable invCount Size");
			invCount = new int[invObjects.Length];
		}
		else
			invCount = invCountArray;
	}
	
	//Adds the contents of one InvPacker to another, if they share a type
	public void AddInv(InvPacker addedItems)
	{
		ItemSO[] addItems = addedItems.GetInvObjects();
		int[] addItemsCount = addedItems.GetInvCount();
		for(int item = 0; item < invObjects.Length; item++)
		{
			for(int addItem = 0; addItem < addItems.Length; addItem++)
			{
				if(invObjects[item] == addItems[addItem])
				{
					invCount[item] += addItemsCount[addItem];
				}
			}
		}
	}
	
	//Passes the contents of the InvPacker to an inventory, while subtracting the quantity of that resources in InvPacker
	public void PassToInv(InventoryManager inventory)
	{
		InventoryManager playerInv  = FindObjectOfType<InventoryManager>(); //TEMP
		for(int res = 0; res < invObjects.Length; res++)
		{
			for(;invCount[res] > 0; invCount[res]--)
				playerInv.AddItem(invObjects[res]);
		}
	}
	
	//empties the inventory
	public void ClearInv()
	{
		invCount = new int[invObjects.Length];
	}
	
	public void SetInvCount(int[] newCount)
	{
		if(invObjects.Length != newCount.Length)
		{
			Debug.Log("InvPacker: Incompatable invCount Size");
			invCount = new int[invObjects.Length];
		}
		invCount = newCount;
	}
	
	public ItemSO[] GetInvObjects() { return invObjects; }
	public int[] GetInvCount() { return invCount; }
	public int GetSize(){ return invObjects.Length; }
	
	public string GetDetails()
	{
		string invRecord =  "This InvPacker is of length: ";
		invRecord += GetSize();
		invRecord += "\nThis InvPacker has: ";
		for(int index = 0; index < GetSize(); index++)
		{
			invRecord += invCount[index];
			invRecord += " of ";
			invRecord += invObjects[index].ToString();
			invRecord += ", ";
		}
		return invRecord;
	}
}
