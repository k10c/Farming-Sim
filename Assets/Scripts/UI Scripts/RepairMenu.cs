using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// written by Aidan
// YES ik i use getcomponent but I believe this was by far the simplest way to implement the desired behaviors

public class RepairMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] 
    private RepairObjective[] objectives;
    [SerializeField]
    private Slider progressBar;
    [SerializeField]
    private int numPlayers;
    [SerializeField]
    private GameObject bot;


    private bool isOpen = false;
    private int numCompleteObjectives = 0;
    private GameObject currPlayer;
    // private Inventory inventory;

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < objectives.Length; i++)
        {
            objectives[i].attemptToComplete += attemptToComplete;
            objectives[i].setID(i);
            if (numPlayers > 1)
            {
                objectives[i].scaleQuantity();
            }
        }
        // inventory = FindObjectOfType<InventoryHolder>().inventory;
    }

    public void toggle(GameObject player)
    {
        if (!isOpen)
        {
            menu.SetActive(true);
            player.GetComponent<PlayerMovement>().enabled = false;
            currPlayer = player;
            isOpen = true;
        }
        else
        {
            menu.SetActive(false);
            player.GetComponent<PlayerMovement>().enabled = true;
            isOpen = false;
        }
        
    }

    private void updateProgress()
    {
        numCompleteObjectives++;
        progressBar.value = ((float)numCompleteObjectives/(float)objectives.Length);

        Debug.Log(progressBar.value);
        
        if (progressBar.value == .5f)
        {
            bot.SetActive(true);
        }

        if(progressBar.value == 1.0f )
        {
            win();
        }
    }

    private void attemptToComplete(int objectiveID)
    {
        int amountReqd = objectives[objectiveID].getRequiredQuantity();
        ItemInfo resourceReqd = objectives[objectiveID].getResource();
        Inventory currInventory = currPlayer.GetComponent< InventoryHolder>().inventory;

        int amountHeld = currInventory.GetAmountOfCertainItem(resourceReqd);


        if(amountHeld >= amountReqd)
        {
            currInventory.UpdateAmount(resourceReqd, amountHeld - amountReqd);
            objectives[objectiveID].complete();
            updateProgress();
        } 
    }

    private void win()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("Win");
    }

}
