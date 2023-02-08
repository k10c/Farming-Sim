using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

// The interfaces are used to enable the items to be dragged around
public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    [SerializeField] private Image image;
    public TextMeshProUGUI countText;

    [HideInInspector] public Transform parentBeforeDrag;
    [HideInInspector] public ItemSO item;
    [HideInInspector] public int count = 1;

    // Displays how many items are stacked on each other in the inventory
    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textActive = (count <= 1) ? false : true;
        countText.gameObject.SetActive(textActive);
    }

    // Sets item sprite
    public void InitializeItem(ItemSO newItemSO)
    {
        item = newItemSO;
        image.sprite = newItemSO.image;     
        RefreshCount();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;    // Allows mouse to see behind object being dragged
        parentBeforeDrag = transform.parent;    // The parent of the dragged item before being moved 
        transform.SetParent(transform.root);    // Makes sure object appears infront of inventory UI
    }

    // Moves object being dragged to wherever mouse is
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    // Snaps object in inventory slot it is over or if not hover new slot the slot it came from
    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentBeforeDrag);
    }
}