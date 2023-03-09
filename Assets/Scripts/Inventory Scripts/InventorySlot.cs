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
    
    public int GetStackSize() { return stackSize; }

    public ItemInfo GetItemInfo() { return itemInfo; }

    public InventorySlot() { ClearInventorySlot(); }

    public InventorySlot(ItemInfo info)     // When a new inventory slot object is made it is given the data of the item being picked up
    {
        itemInfo = info;
        AddToStack();
    }

    public void UpdateInventorySlot(ItemInfo info)      // Updates an existing inventory slot
    {
        itemInfo = info;
        AddToStack();
    }

    public void AddToStack()
    {
        stackSize++;
    }

    public void RemoveFromStack()
    {
        stackSize--;
    }

    public void ClearInventorySlot()
    {
        itemInfo = null;
        stackSize = 0;
    }


}

