using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by Jose

public class PlayerPlant : MonoBehaviour
{
    [SerializeField] private ItemInfo[] infoArr;    // Holds the seed info
    [SerializeField] private GameObject[] plantArr;     // Holds the gameobject info
    [SerializeField] private Transform playerPos;
    private Dictionary<ItemInfo, GameObject> seedPlantDictionary = new Dictionary<ItemInfo, GameObject>();

    // Assigns a plant object to a seed
    private void Start()
    {
        for (int i = 0; i < infoArr.Length; i++)
        {
            seedPlantDictionary.Add(infoArr[i], plantArr[i]);
        }
    }

    // Plants a plant from a seed in the inventory
    public void Plant(ItemInfo info)
    {
        if (seedPlantDictionary.TryGetValue(info, out GameObject plant))
        {
            Instantiate(plant, playerPos.position, playerPos.rotation);
        }
    }
	
	//Used to help with online multiplayer
	public void SetPlayerPos(Transform newPlayerPos)
	{
		playerPos = newPlayerPos;
	}
}
