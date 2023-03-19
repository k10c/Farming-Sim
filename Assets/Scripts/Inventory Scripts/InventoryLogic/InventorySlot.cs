using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using System;

[Serializable]
public class InventorySlot 
{
    [SerializeField] private ItemInfo itemInfo;
    [SerializeField] private int stackSize;

    // Returns the stack size of an inventory item
    public int GetStackSize() { return stackSize; }

    // Returns the info of an inventory item
    public ItemInfo GetItemInfo() { return itemInfo; }

    // Clears an inventory slot so that is is blank when it is made
    public InventorySlot() { ClearInventorySlot(); }

    // Updates an existing inventory slot 
    public void UpdateInventorySlot(ItemInfo info, int quant)      
    {
        itemInfo = info;
        AddToStack(quant);
    }

    // Increments the stack size of an inventory slot to the quantity of the item being picked up
    public void AddToStack(int quant)
    {
        stackSize += quant;
    }

    // Decrements the stack size of an inventory slot
    public void RemoveFromStack()
    {
        stackSize--;
    }

    // Clears an inventory slot
    public void ClearInventorySlot()
    {
        itemInfo = null;
        stackSize = 0;
    }
}

