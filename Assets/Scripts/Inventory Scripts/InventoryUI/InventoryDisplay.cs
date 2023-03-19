using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    // Player that holds the inventory
    [SerializeField] private InventoryHolder inventoryHolder;
    // UI inventory slots
    [SerializeField] private InventorySlotUI[] slots;
    // Script allowing the player to plant
    [SerializeField] private PlayerPlant playerPlant;

    private int selectedSlot = 0;
    private int previouslySelectedSlot = -1;

    // Players inventory
    private Inventory inventory;
    // Dictionary storing the assignments of the inventory and inventory ui slots
    private Dictionary<InventorySlotUI, InventorySlot> slotDictionary;
    // Information of the slot that is currently selected
    private ItemInfo selectedSlotItemInfo;

    // Assigns players inventory to the inventory variable
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

        // Makes the first slot to appear selected
        ChangeSelectedSlot(selectedSlot, previouslySelectedSlot);
        AssignSlot(inventory);
    }

    // Assigns all the inventory slots to a ui slot
    private void AssignSlot(Inventory inventoryToDisplay)
    {
        slotDictionary = new Dictionary<InventorySlotUI, InventorySlot>();

        for (int i = 0; i < inventoryToDisplay.GetInventorySize(); i++)
        {
            slotDictionary.Add(slots[i], inventoryToDisplay.GetInventorySlots()[i]);
            slots[i].InitializeSlotUI(inventoryToDisplay.GetInventorySlots()[i]);
        }
    }

    // Updates a slot to whatever change happens
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

    // Initializes a slot 
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

    // Displays which slot is selected
    private void ChangeSelectedSlot(int newSlot, int oldSlot)
    {
        slots[newSlot].Select();

        if (oldSlot > -1)
            slots[oldSlot].Deselect();
    }

    // Returns the info of whatever slot is being highlighted
    private ItemInfo GetSelectedSlotInfo(int slot)
    {
        return selectedSlotItemInfo = slots[slot].GetAssignedInventorySlot().GetItemInfo();
    }

    // Removes item from the inventory and updates ui
    private void RemoveItem(int player)
    {
        if (player == 1 && 
            slots[selectedSlot].GetAssignedInventorySlot().GetItemInfo() != null && 
            slots[selectedSlot].GetAssignedInventorySlot().GetItemInfo().itemType == ItemType.Seed &&
            Input.GetKeyDown(KeyCode.F))
        {
            playerPlant.Plant(GetSelectedSlotInfo(selectedSlot));
            inventory.RemoveFromInventory(slotDictionary, slots[selectedSlot]);
        }

        else if (player == 2 &&
            slots[selectedSlot].GetAssignedInventorySlot().GetItemInfo() != null && 
            slots[selectedSlot].GetAssignedInventorySlot().GetItemInfo().itemType == ItemType.Seed &&
            Input.GetKeyDown(KeyCode.H))
        {
            playerPlant.Plant(GetSelectedSlotInfo(selectedSlot));
            inventory.RemoveFromInventory(slotDictionary, slots[selectedSlot]);
        }
    }

    // Keeps slot selection in bounds highlights the right slot
    private void KeepSelectionInBounds(int player)
    {
        if (selectedSlot < slots.Length - 1 && Input.GetKeyDown(KeyCode.E) && player == 1)
        {
            previouslySelectedSlot = selectedSlot;
            selectedSlot++;
            ChangeSelectedSlot(selectedSlot, previouslySelectedSlot);
        }
        else if (selectedSlot > 0 && Input.GetKeyDown(KeyCode.Q) && player == 1)
        {
            previouslySelectedSlot = selectedSlot;
            selectedSlot--;
            ChangeSelectedSlot(selectedSlot, previouslySelectedSlot);
        }

        if (selectedSlot < slots.Length - 1 && Input.GetKeyDown(KeyCode.O) && player == 2)
        {
            previouslySelectedSlot = selectedSlot;
            selectedSlot++;
            ChangeSelectedSlot(selectedSlot, previouslySelectedSlot);
        }
        else if (selectedSlot > 0 && Input.GetKeyDown(KeyCode.U) && player == 2)
        {
            previouslySelectedSlot = selectedSlot;
            selectedSlot--;
            ChangeSelectedSlot(selectedSlot, previouslySelectedSlot);
        }
    }

    private void Update()
    {
        KeepSelectionInBounds(inventoryHolder.player);
        RemoveItem(inventoryHolder.player);
    }
}
