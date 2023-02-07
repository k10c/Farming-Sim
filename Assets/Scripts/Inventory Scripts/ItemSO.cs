using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable object/Item")]

public class ItemSO : ScriptableObject
{
    public ItemType type;

    [Header("Only UI")]
    public bool stackable = true;

    [Header("Both")]
    public Sprite image;    

    public enum ItemType
    {
        Plant,
        Seed,
        Tool
    }

    public enum ActionType
    {
        Action1,
        Action2
    }
}
