using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class InventoryHolder : MonoBehaviour
{
    [SerializeField] private int inventorySize;
    [SerializeField] private InventoryDisplay display;

    // Player number so player 1 or player 2
    public int player;
    public Inventory inventory;
    private void Awake()
    {
        inventory = new Inventory(inventorySize);       // Creates an inventory of the size specified. As of now can only stay at 12.
        inventory.inventoryDisplay = display;      // Gets the inventoryDisplay component so that we can use it in the inventory script
    }
}
