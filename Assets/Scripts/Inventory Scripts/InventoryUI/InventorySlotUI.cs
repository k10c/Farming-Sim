using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color deselectedColor;
    [SerializeField] private Image slotImage;
    [SerializeField] private InventorySlot assignedInventorySlot;

    [SerializeField] private Image itemSprite;
    [SerializeField] private Image nameBackground;

    [SerializeField] private TextMeshProUGUI stackCount;
    [SerializeField] private TextMeshProUGUI itemName;

    // Reference to the script that handles display of inventory
    private InventoryDisplay inventoryDisplay;
    // Returns the inventory slot assigned to the ui inventory slot
    public InventorySlot GetAssignedInventorySlot() { return assignedInventorySlot; }

    private void Awake()
    {
        ClearSlotUI();
        inventoryDisplay = transform.parent.GetComponent<InventoryDisplay>();
    }

    // Initializes the slot ui to match the information of the assigned slot
    public void InitializeSlotUI(InventorySlot slot) 
    {
        assignedInventorySlot = slot;
        itemSprite.gameObject.SetActive(true);
        UpdateSlotUI(slot);
    }

    // Clears a slot so that it is empty
    public void ClearSlotUI()
    {
        itemSprite.gameObject.SetActive(false);
        stackCount.gameObject.SetActive(false);
        nameBackground.gameObject.SetActive(false);
        itemName.text = string.Empty;
    }

    // Updates the slot ui to match the information of the assigned slot
    public void UpdateSlotUI(InventorySlot slot)
    {
        if (slot.GetItemInfo() != null && slot.GetStackSize() > 0)
        {
            itemSprite.sprite = slot.GetItemInfo().itemIcon;
            stackCount.text = slot.GetStackSize().ToString();
            nameBackground.gameObject.SetActive(true);
            itemName.text = slot.GetItemInfo().itemName;

            // Activates stack text if true
            if (slot.GetStackSize() > 1)
                stackCount.gameObject.SetActive(true);
        }
        else 
            ClearSlotUI();
    }

    // Changes the slot color to the selected color
    public void Select()
    {
        slotImage.color = selectedColor;
    }

    // Changes the slot color the deselelected color
    public void Deselect()
    {
        slotImage.color = deselectedColor;
    }
}
