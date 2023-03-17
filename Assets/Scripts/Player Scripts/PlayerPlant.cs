using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlant : MonoBehaviour
{
    [SerializeField] private ItemInfo[] infoArr;
    [SerializeField] private GameObject[] plantArr;
    [SerializeField] private Transform playerPos;
    private Dictionary<ItemInfo, GameObject> seedPlantDictionary = new Dictionary<ItemInfo, GameObject>();

    private void Start()
    {
        for (int i = 0; i < infoArr.Length; i++)
        {
            seedPlantDictionary.Add(infoArr[i], plantArr[i]);
        }
    }

    public void Plant(ItemInfo info)
    {
        if (seedPlantDictionary.TryGetValue(info, out GameObject plant))
        {
            Instantiate(plant, playerPos.position, playerPos.rotation);
        }
    }
}
