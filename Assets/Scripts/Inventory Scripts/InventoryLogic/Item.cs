using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// As of now is obsolete

public class Item : MonoBehaviour, ICollectable
{
    // Set the itemInfo in the inspector
    // [SerializeField] private ItemInfo itemInfo;
    private InventoryHolder inventoryHolder;

    [SerializeField] private PlantType type;

    private InvPacker invPacker;

    private void Start()
    {
        inventoryHolder = FindObjectOfType<InventoryHolder>();
    }

    public void Collect()
    {
        
        // invPacker.GetInvObjects();
        // // if (inventoryHolder.inventory.AddToInventory(type.))     // If there is space in the inventory, the item is added and then the gameobject of the item we see is destroyed
        //     Destroy(gameObject);
    }







    // public static event HandleItemCollected OnItemCollected;
    // public delegate void HandleItemCollected(ItemInfo itemInfo);
        // if (OnItemCollected != null)
        //     OnItemCollected(itemInfo);

}
