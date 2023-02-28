using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// written by Aidan

public class RepairMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    private bool isOpen = false;
    // Start is called before the first frame update
    public void toggle(GameObject player)
    {
        if (!isOpen)
        {
            menu.SetActive(true);
            player.SetActive(false);
            isOpen = true;
        }
        else
        {
            menu.SetActive(false);
            player.SetActive(true);
        }
        
    }

}
