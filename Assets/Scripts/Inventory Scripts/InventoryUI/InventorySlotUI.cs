using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlotUI : MonoBehaviour
{
    [Header("Slot components")]
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color deselectedColor;
    [SerializeField] private Image slotImage;
    [SerializeField] private InventorySlot assignedInventorySlot;

    [Header("Item components")]
    [SerializeField] private Image itemSprite;
    [SerializeField] private Image nameBackground;

    [SerializeField] private TextMeshProUGUI stackCount;
    [SerializeField] private TextMeshProUGUI itemName;


    public InventoryDisplay inventoryDisplay { get; private set; }
    public InventorySlot GetAssignedInventorySlot() { return assignedInventorySlot; }

    private void Awake()
    {
        ClearSlotUI();

        inventoryDisplay = transform.parent.GetComponent<InventoryDisplay>();
    }

    public void InitializeSlotUI(InventorySlot slot)    // Initializes slot UI
    {
        assignedInventorySlot = slot;
        Debug.Log("initial slot ui");
        itemSprite.gameObject.SetActive(true);
        UpdateSlotUI(slot);
    }

    public void ClearSlotUI()
    {
        itemSprite.gameObject.SetActive(false);
        stackCount.gameObject.SetActive(false);
        nameBackground.gameObject.SetActive(false);
        itemName.text = string.Empty;
    }

    public void UpdateSlotUI(InventorySlot slot)
    {
        if (slot.GetItemInfo() != null && slot.GetStackSize() > 0)
        {
            Debug.Log("update ui");
            itemSprite.sprite = slot.GetItemInfo().itemIcon;
            stackCount.text = slot.GetStackSize().ToString();
            nameBackground.gameObject.SetActive(true);
            itemName.text = slot.GetItemInfo().itemName;

            if (slot.GetStackSize() > 1)
            {
                stackCount.gameObject.SetActive(true);
            }
        }
        else 
        {
            ClearSlotUI();
            Debug.Log("cleared");
        }
    }

    public void Select()
    {
        slotImage.color = selectedColor;
    }

    public void Deselect()
    {
        slotImage.color = deselectedColor;
    }
}
