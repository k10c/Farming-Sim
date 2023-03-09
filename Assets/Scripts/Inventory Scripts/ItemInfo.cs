using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Sriptable Object/Item")]
public class ItemInfo : ScriptableObject
{
    public string itemName;  
    [TextArea(1, 4)]
    public string itemDescription;
    public bool stackable = false;
    public int maxStackSize;
    public ItemType itemType;
    public Sprite itemIcon;
}
