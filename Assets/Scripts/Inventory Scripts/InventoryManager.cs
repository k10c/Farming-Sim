using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int maxStackedItems = 4;
    public InventorySlot[] inventorySlots;
    [SerializeField] private GameObject inventoryItemPrefab;
    [SerializeField] private GameObject mainInventory;

    public bool AddItem(ItemSO itemSO)
    {

        // Stacking logic for stackable items
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.item == itemSO && itemInSlot.count < maxStackedItems && itemInSlot.item.stackable)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }

        // Spawns 
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(itemSO, slot);
                return true;
            }
        }
        return false;
    }

    // Instantiates new items in empty inventory slot
    private void SpawnNewItem(ItemSO itemSO, InventorySlot slot)
    {
        GameObject newItemGameObject = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGameObject.GetComponent<InventoryItem>();
        inventoryItem.InitializeItem(itemSO);
    }

    // Open and close main inventory with I
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !mainInventory.gameObject.activeSelf)
        {
            mainInventory.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.I) && mainInventory.gameObject.activeSelf)
        {
            mainInventory.gameObject.SetActive(false);
        }
    }
}
