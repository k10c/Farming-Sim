using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private InventoryHolder inventoryHolder;
    [SerializeField] private InventorySlotUI[] slots;
    [SerializeField] private PlayerPlant playerPlant;

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

    private ItemInfo GetSelectedSlotInfo(int slot)
    {
        return selectedSlotItemInfo = slots[slot].GetAssignedInventorySlot().GetItemInfo();
    }

    private void Update()
    {
        // Keeps slot selection in bounds highlights the right slot
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

        // Removes item from the inventory and updates ui
        if (slots[selectedSlot].GetAssignedInventorySlot().GetItemInfo() != null && 
            slots[selectedSlot].GetAssignedInventorySlot().GetItemInfo().itemType == ItemType.Seed &&
            Input.GetKeyDown(KeyCode.F))
        {
            playerPlant.Plant(GetSelectedSlotInfo(selectedSlot));
            inventory.RemoveFromInventory(slotDictionary, slots[selectedSlot]);
        }

        // if (slots[selectedSlot].GetAssignedInventorySlot().GetItemInfo() != null && 
        //     slots[selectedSlot].GetAssignedInventorySlot().GetItemInfo().itemType == ItemType.Seed &&
        //     Input.GetKeyDown(KeyCode.K))
        // {
            
        // }
    }
}
