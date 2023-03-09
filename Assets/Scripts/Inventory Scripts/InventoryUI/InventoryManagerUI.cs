using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Left of:
// Trying to make finding an empty slot its own function
// Trying to figure out how to make an item the alread has a full slot spawn in an empty slot.


public class InventoryManagerUI : MonoBehaviour
{
    private InventoryHolder inventoryHolder;
    private Inventory inventory;

    private InventorySlotUI inventorySlotUI;

    private void Start()
    {
        inventoryHolder = FindObjectOfType<InventoryHolder>();
        inventorySlotUI = GetComponentInChildren<InventorySlotUI>();
        inventory = inventoryHolder.inventory;
    }

    

    // [SerializeField] private List<InventorySlotUI> slots = new List<InventorySlotUI>(12);
    // [SerializeField] private GameObject inventoryItemUIPrefab;
    // private Transform parent;
    // private int selectedSlot = 0;
    // private int previouslySelected = -1;

    // // Add item in an empty slot or increment stack size if it can be
    // // If the item in the slot is the same as the one being added, then add
    // // to the stack size
    // // If the item is new or ths stack is full, then add to an empty slot
    // // If slot is empty, add the inventory item to that slot. Could be own method
 
    // private void Start()
    // {    
    //     ChangeSelectedSlot(selectedSlot, previouslySelected);
    // }

    // private void Update()
    // {
    //     if (selectedSlot < 11 && Input.GetKeyDown(KeyCode.E))
    //     {
    //         previouslySelected = selectedSlot;
    //         selectedSlot++;
    //         ChangeSelectedSlot(selectedSlot, previouslySelected);
    //     }
    //     else if (selectedSlot > 0 && Input.GetKeyDown(KeyCode.Q))
    //     {
    //         previouslySelected = selectedSlot;
    //         selectedSlot--;
    //         ChangeSelectedSlot(selectedSlot, previouslySelected);
    //     }
    // }

    // public void AddNewItemtoSlot(InventorySlot inventoryItem)
    // {        
    //     if (FindEmptySlot() != null)
    //     {
    //         parent = FindEmptySlot().transform;
    //         Instantiate(SetUpItem(inventoryItem), parent);
    //     }
    //     else    
    //         Debug.LogError("No empty slots");
    // }

    // // Have to check if items are stackable and also have to set the stack limit for the items
    // public void StackLikeItems(InventorySlot inventoryItem)
    // {
    //     foreach (var slot in slots)
    //     {
    //         InventoryItemUI slotItemUI = slot.GetComponentInChildren<InventoryItemUI>();
    //         ItemInfo inventoryItemInfo = inventoryItem.ItemInfo;

    //         // Checks to see if the info of the slot in the loop is the same as the item picked up
    //         // if it is then the count is refreshed
    //         if (slotItemUI.itemInfo == inventoryItemInfo)
    //         {
    //             slotItemUI.RefreshCount(inventoryItem);
    //             break;
    //         }
    //     }
    // }

    // // public void AddSameItemToNewSlot(InventoryItem inventoryItem)
    // // {
    // //     if (FindEmptySlot() != null)
    // //     {
    // //         parent = FindEmptySlot().transform;
    // //         Instantiate(inventoryItem, parent);
    // //     }
    // //     else    
    // //         Debug.LogError("No empty slots");
    // // }

    // private void ChangeSelectedSlot(int newSlot, int oldSlot)
    // {
    //     slots[newSlot].Select();

    //     if (oldSlot > -1)
    //         slots[oldSlot].Deselect();
    // }

    // private InventorySlotUI FindEmptySlot()
    // {
    //     foreach (var slot in slots)
    //     {
    //         if (slot.transform.childCount == 0)
    //             return slot;
    //     }
    //     return null;
    // }
    
    // private InventoryItemUI SetUpItem(InventorySlot item)
    // {
    //     InventoryItemUI newItemUI = inventoryItemUIPrefab.GetComponent<InventoryItemUI>();
    //     newItemUI.InitializeItemUI(item);
    //     return newItemUI;
    // }


    // [SerializeField] private InventorySlotUI[] inventorySlots;
    // [SerializeField] private InventoryItemUI inventoryItemUI;

    // private void AddItemToEmptySlot()
    // {
    //     for (int i = 0; i < inventorySlots.Length; i++) 
    //     {
    //         InventorySlotUI slot = inventorySlots[i];
    //         if (slot.GetComponentInChildren<InventoryItemUI>() == null)
    //         {
    //             SpawnNewItemUI(slot);
    //         }
    //     }
    // }

    // private void SpawnNewItemUI(InventorySlotUI slot)
    // {
        
    // }
}
