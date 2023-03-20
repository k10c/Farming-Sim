using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

[Serializable]
public class Inventory 
{
    public InventoryDisplay inventoryDisplay; 
    [SerializeField] private List<InventorySlot> inventorySlots;    // Inventory slots in the inventory
    public List<InventorySlot> GetInventorySlots() { return inventorySlots; }   // Returns inventory slot
    public int GetInventorySize() { return inventorySlots.Count; }  // Returns the size of the inventory

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
            InventorySlot slot = ContainsItem(info);
            slot.AddToStack(quant);
            inventoryDisplay.UpdateSlot(slot);
            return true;
        }
        else if (FindEmptySlot() != null)       // If item is not in the list look for empty slot      
        {
            InventorySlot emptySlot = FindEmptySlot();
            emptySlot.UpdateInventorySlot(info, quant);
            inventoryDisplay.InitializeSlot(emptySlot);
            return true;
        }
        return false;
    } 

    // Removes items from the inventory
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

    public int GetAmountOfCertainItem(ItemInfo info)    // Returns the total amount of an item
    {
        int itemCount = 0;

        foreach (var slot in inventorySlots)  
        {
            if (slot.GetItemInfo() == info)
                itemCount += slot.GetStackSize();
        }  

        return itemCount;
    }

    public void UpdateAmount(ItemInfo info, int newAmount)
    {
        // sets the amount of the item contained in that players inventory to either 0 or the new amount, doesnt really matter cuz items only get used once
        InventorySlot slotWithItem = ContainsItem(info);
        slotWithItem.UpdateStackSize(newAmount);
        inventoryDisplay.UpdateSlot(slotWithItem);
    }
}
