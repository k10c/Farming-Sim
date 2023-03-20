using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlinePlayerInventory : MonoBehaviour
{
	[SerializeField] private InventoryDisplay invDisp;
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
