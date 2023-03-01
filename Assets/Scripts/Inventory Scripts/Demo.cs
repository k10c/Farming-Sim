using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public ItemSO[] itemsToPickUp;

    public void PickupItem(int id)
    {
        bool result = inventoryManager.AddItem(itemsToPickUp[id]);
        if (result)
        {

        }
    }
}