using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

[Serializable]
public class Inventory 
{
    public InventoryDisplay inventoryDisplay;
    [SerializeField] private List<InventorySlot> inventorySlots;
    public List<InventorySlot> GetInventorySlots() { return inventorySlots; }
    public int GetInventorySize() { return inventorySlots.Count; }

    public Inventory(int size)      // Constructor that creates the list of the given size with empty slot
    {
        inventorySlots = new List<InventorySlot>(size);

        for (int i = 0; i < size; i++)
        {
            inventorySlots.Add(new InventorySlot());
        }
    }

    public bool AddToInventory(ItemInfo info, int quant)
    {
        if (ContainsItem(info) != null)     // If item is in the list and the stack isn't full, just increase stack size (&& ContainsItem(info).GetStackSize() <= info.maxStackSize)
        {
            Debug.Log("Already here");

            InventorySlot slot = ContainsItem(info);
            slot.AddToStack(quant);
            inventoryDisplay.UpdateSlot(slot);
            return true;
        }
        else if (FindEmptySlot() != null)       // If item is not in the list look for empty slot      
        {
            Debug.Log("New");

            InventorySlot emptySlot = FindEmptySlot();
            emptySlot.UpdateInventorySlot(info, quant);
            inventoryDisplay.InitializeSlot(emptySlot);

            // Debug.Log($"{info.itemName} added for the first time");
            return true;
        }
        return false;
    } 

    public void RemoveFromInventory(Dictionary<InventorySlotUI, InventorySlot> dictionary, InventorySlotUI slotUI)
    {
        
        if (dictionary.TryGetValue(slotUI, out InventorySlot slot))
        {
            slot.RemoveFromStack();
            inventoryDisplay.UpdateSlot(slot);
            if (slot.GetStackSize() <= 0)
            {
                slot.ClearInventorySlot();
            }
        }
    }

    private InventorySlot ContainsItem(ItemInfo info)   // Looks for a slot with the info we're looking for that has space
    {
        foreach (var slot in inventorySlots)
        {
            if (slot.GetItemInfo() == info && slot.GetStackSize() < info.maxStackSize)
                return slot;
        }

        Debug.Log($"{info.itemName} is not in any slot");
        return null;
    }

    private InventorySlot FindEmptySlot()   // Looks for an empty slot
    {
        foreach (var slot in inventorySlots)
        {
            if (slot.GetItemInfo() == null)
                return slot;
        }

        Debug.Log("No empty slots");
        return null;
    }

    public int GetAmountOfCertainItem(ItemInfo info)
    {
        int itemCount = 0;

        foreach (var slot in inventorySlots)  
        {
            if (slot.GetItemInfo() == info)
                itemCount += slot.GetStackSize();
        }  

        return itemCount;
    }
        
    // {
    // // private Dictionary<ItemInfo, InventoryItem> inventoryDictionary = new Dictionary<ItemInfo, InventoryItem>();
    //     // {
    //     // // If we find the item in the dictionary then we just increase the stack size
    //     // // if (inventoryDictionary.TryGetValue(info, out InventoryItem item))
    //     // // {
    //     // //     if (item.ItemInfo.stackable && item.StackSize <= item.MAXSTACKSIZE)
    //     // //     {
    //     // //         item.AddToStack();
    //     // //         inventoryManagerUI.StackLikeItems(item);
    //     // //         Debug.Log($"{item.StackSize} {item.ItemInfo.itemName} added");
    //     // //     }
    //     // //     else if (item.ItemInfo.stackable && item.StackSize > item.MAXSTACKSIZE)
    //     // //     {
    //     // //         item.AddToStack();
    //     // //         inventoryManagerUI.AddNewItemtoSlot(item);
    //     // //         inventoryManagerUI.StackLikeItems(item);
    //     // //         Debug.Log($"{item.ItemInfo.itemName} added new stack");
    //     // //     }
    //     // //     else if (!item.ItemInfo.stackable)
    //     // //     {
    //     // //         item.AddToStack();
    //     // //         inventoryManagerUI.AddNewItemtoSlot(item);
    //     // //         Debug.Log($"{item.StackSize} {item.ItemInfo.itemName} added to new slot");
    //     // //     }
    //     // // }
    //     // }
    //     // {
    //     // // If don't find the item then we create a new inventory item and add it to both the inventory and the dictionary
    //     // // else
    //     // // {
    //     // //     InventoryItem newItem = new InventoryItem(info); 
    //     // //     inventory.Add(newItem);
    //     // //     inventoryDictionary.Add(info, newItem);
    //     // //     inventoryManagerUI.AddNewItemtoSlot(newItem);
    //     // //     Debug.Log($"{newItem.ItemInfo.itemName} added for the first time");
    //     // // }
    //     // }

    // }

    // public void RemoveFromInventory(ItemInfo info)
    // {
    //     // If we find the item in the dictionary then we just decrease the stack size
    //     if (inventoryDictionary.TryGetValue(info, out InventoryItem item))
    //     {
    //         if (item.StackSize > 1)
    //             item.RemoveFromStack();
    //         else
    //         {
    //             inventory.Remove(item);
    //             // inventoryDictionary.Remove(info);
    //         }
    //     }
    // }
    // }
}
