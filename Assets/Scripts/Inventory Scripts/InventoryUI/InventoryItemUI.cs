using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour
{
    // // The image and text components of the inventory item prefab
    // [Header("Prefab Components")]
    // [SerializeField] private TextMeshProUGUI stackCountText;
    // [SerializeField] private Image itemIconUI;
    // public ItemInfo itemInfo;
    // private int numberOfStacks = 1;

    // // Sets the info to the item passed, and the sprite to the item passed, and the count is disabled
    // public void InitializeItemUI(InventorySlot inventoryItem)
    // {
    //     itemInfo = inventoryItem.ItemInfo;
    //     itemIconUI.sprite = inventoryItem.ItemInfo.itemIcon;
    //     stackCountText.gameObject.SetActive(false);
    // }
    
    // // Refreshes the count of the item passed
    // public void RefreshCount(InventorySlot inventoryItem)
    // {
    //     stackCountText.text = inventoryItem.StackSize.ToString();
    //     if (inventoryItem.StackSize > 1)
    //         stackCountText.gameObject.SetActive(true);
    // }

    // // get the item info

    // // [SerializeField] private InventoryItem inventoryItem;
    // [SerializeField] private GameObject inventoryItemUIPrefab;
    // public ItemInfo itemInfo;

    // [Header("Prefab Components")]
    // [SerializeField] private TextMeshProUGUI stackCountText;
    // [SerializeField] private Image itemIconUI;

    // public void RefreshCount()
    // {
    //     // stackCountText.text = inventoryItem.StackSize.ToString();
    //     if (inventoryItem.StackSize > 1)    
    //         stackCountText.gameObject.SetActive(true);
    // }

    // private void ClearItemUI()
    // {
    //     stackCountText.gameObject.SetActive(false);
    //     itemIconUI.gameObject.SetActive(false);
    // }

    // // public void SetItemImage()
    // // {
    // //     itemIconUI.sprite = inventoryItem.ItemInfo.itemIcon;
    // // }

    // public void InitializeItem(ItemInfo info)
    // {
    //     itemInfo = info;
    //     // SetItemImage();
    //     RefreshCount();
    // }
    
    // Oldest version
    // [SerializeField] private Image uiItemImage;
    // [SerializeField] private TextMeshProUGUI stackText;
    // [SerializeField] private InventoryItem inventoryItem;

    // public void ClearItemUI()
    // {
    //     uiItemImage.gameObject.SetActive(false);
    //     stackText.gameObject.SetActive(false);
    // }

    // private void RefreshCount()
    // {
    //     stackText.text = inventoryItem.StackSize.ToString();

    //     if (inventoryItem.StackSize > 1)
    //         stackText.gameObject.SetActive(true);
    // }

    // public void DrawItemUI()
    // {
    //     uiItemImage.sprite = inventoryItem.ItemInfo.itemIcon;
    //     RefreshCount();
    // }
}
