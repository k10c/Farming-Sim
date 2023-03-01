using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image image;
    public Color selectedColor;
    public Color notSelectedColor;

    private void Awake()
    {
        Deselected();
    }

    public void Selected()
    {
        image.color = selectedColor;
    }

    public void Deselected()
    {
        image.color = notSelectedColor;
    }

    // Allows items to be placed in empty item slots
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            InventoryItem inventoryItem = dropped.GetComponent<InventoryItem>();
            inventoryItem.parentBeforeDrag = transform;
        }
    }
}
