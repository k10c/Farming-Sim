using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable object/Item")]

public class ItemSO : ScriptableObject
{
    public ItemType type;

    public bool stackable = true;

    public Sprite image;    

    public enum ItemType
    {
        Plant,
        Seed,
        Tool
    }

    /*public enum ActionType
    {
        
    }*/
}
