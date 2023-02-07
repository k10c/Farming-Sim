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

    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public ItemSO item;
    [HideInInspector] public int count = 1;

    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textActive = (count <= 1) ? false : true;
        countText.gameObject.SetActive(textActive);
    }

    public void InitializeItem(ItemSO newItemSO)
    {
        item = newItemSO;
        image.sprite = newItemSO.image;
        RefreshCount();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }
}