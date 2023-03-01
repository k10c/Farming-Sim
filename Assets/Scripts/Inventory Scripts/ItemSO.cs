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
	
	public GameObject plant;
	
    /*public enum ActionType
    {
        
    }*/
	
	public bool Plant(Vector3 pos, Quaternion rot)
	{
		pos = Camera.main.ScreenToWorldPoint(pos);
		if(type == ItemType.Seed)
		{
			Instantiate(plant, new Vector3(pos.x,pos.y,0), rot);
			return true;
		}
		else
			return false;
	}
}
