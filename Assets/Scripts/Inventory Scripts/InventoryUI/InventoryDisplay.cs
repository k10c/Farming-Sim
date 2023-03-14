using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private InventoryHolder inventoryHolder;
    [SerializeField] private InventorySlotUI[] slots;

    private int selectedSlot = 0;
    private int previouslySelectedSlot = -1;

    public Inventory inventory;
    public Dictionary<InventorySlotUI, InventorySlot> slotDictionary;

    public ItemInfo selectedSlotItemInfo { get; private set; }

    private void Start()
    {
        if (inventoryHolder != null)
        {
            inventory = inventoryHolder.inventory;
        }
        else 
        {
            Debug.LogWarning($"No inventory assigned to {this.gameObject}");
        }

        ChangeSelectedSlot(selectedSlot, previouslySelectedSlot);
        AssignSlot(inventory);
    }

    public void AssignSlot(Inventory inventoryToDisplay)
    {
        slotDictionary = new Dictionary<InventorySlotUI, InventorySlot>();

        for (int i = 0; i < inventoryToDisplay.GetInventorySize(); i++)
        {
            slotDictionary.Add(slots[i], inventoryToDisplay.GetInventorySlots()[i]);
            slots[i].InitializeSlotUI(inventoryToDisplay.GetInventorySlots()[i]);
        }
    }

    public void UpdateSlot(InventorySlot updatedSlot)
    {
        foreach (var slot in slotDictionary)
        {
            if (slot.Value == updatedSlot)
            {
                slot.Key.UpdateSlotUI(updatedSlot);
            }
        }
    }

    public void InitializeSlot(InventorySlot updatedSlot)
    {
        foreach (var slot in slotDictionary)
        {
            if (slot.Value == updatedSlot)
            {
                slot.Key.InitializeSlotUI(updatedSlot);
            }
        }
    }

    private void ChangeSelectedSlot(int newSlot, int oldSlot)
    {
        slots[newSlot].Select();

        if (oldSlot > -1)
            slots[oldSlot].Deselect();
    }

    private void GetSelectedSlotInfo(int slot)
    {
        selectedSlotItemInfo = slots[slot].GetAssignedInventorySlot().GetItemInfo();
        Debug.Log($"contains {selectedSlotItemInfo.itemName}");
    }

    private void Update()
    {
        if (selectedSlot < 11 && Input.GetKeyDown(KeyCode.E))
        {
            previouslySelectedSlot = selectedSlot;
            selectedSlot++;
            ChangeSelectedSlot(selectedSlot, previouslySelectedSlot);
        }
        else if (selectedSlot > 0 && Input.GetKeyDown(KeyCode.Q))
        {
            previouslySelectedSlot = selectedSlot;
            selectedSlot--;
            ChangeSelectedSlot(selectedSlot, previouslySelectedSlot);
        }

        if (slots[selectedSlot].GetAssignedInventorySlot().GetItemInfo() != null && Input.GetKeyDown(KeyCode.F))
        {
            GetSelectedSlotInfo(selectedSlot);
            // inventory.RemoveFromInventory(selectedSlotItemInfo);
            inventory.RemoveFromInventory(slotDictionary, slots[selectedSlot]);
        }
    }
}
