using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int maxStackedItems;
    public InventorySlot[] inventorySlots;
    [SerializeField] private GameObject inventoryItemPrefab;
    [SerializeField] private GameObject mainInventory;

    private int selectedSlot = -1;
    int newSelection = 0;

    private void Start()
    {
        ChangeSelectedSlot(0);
    }

    private void ChangeSelectedSlot(int newSelectedSlot)
    {
        if (selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].Deselected();
        }

        inventorySlots[newSelectedSlot].Selected();
        selectedSlot = newSelectedSlot;
    }

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

    // Returns the item corresponding to the slot you are in. The slots go from 0 - 7
    public ItemSO GetSelectedItem(bool use)
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null)
        {
            ItemSO item = itemInSlot.item;
            if (use == true)
            {
                itemInSlot.count--;
                if (itemInSlot.count <= 0)
                {
                    Destroy(itemInSlot.gameObject);
                }
                else
                {
                    itemInSlot.RefreshCount();
                }
            }
            return item;
        }
        else
            return null;
    }

    // Open and close main inventory with I
    private void Update()
    {
		//has to be commented out for current control scheme
		/*
        if (Input.GetKeyDown(KeyCode.I) && !mainInventory.gameObject.activeSelf)
        {
            mainInventory.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.I) && mainInventory.gameObject.activeSelf)
        {
            mainInventory.gameObject.SetActive(false);
        }
		*/

        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (newSelection < 7)
            {
                newSelection++;
                ChangeSelectedSlot(newSelection);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if(newSelection > 0)
            {
                newSelection--;
                ChangeSelectedSlot(newSelection);
            }
        }
    }
}
