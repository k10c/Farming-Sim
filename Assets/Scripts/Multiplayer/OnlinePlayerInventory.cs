using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by Ben
//Used to help set up the various inventory elements (such as those in the OnlinePlayer prefab and the InventoryBar prefab).

public class OnlinePlayerInventory : MonoBehaviour
{
	private InventoryDisplay invDisp;
	[SerializeField] private InventoryHolder playerInv;
	[SerializeField] private PlayerPlant playerPlants;
	
	void Awake()
	{
		invDisp = FindObjectOfType<InventoryDisplay>();
		invDisp.SetInventoryHolder(playerInv);
        invDisp.SetPlayerPlant(playerPlants);
		playerInv.SetDisplay(invDisp);
		playerInv.SetInventory();
		playerPlants.SetPlayerPos(this.transform);
	}
	
    void Start()
    {
		
    }
	
    void Update()
    {
        
    }
}
