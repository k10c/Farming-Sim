using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// written by Aidan

public class RepairMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] 
    private RepairObjective[] objectives;
    [SerializeField]
    private Slider progressBar;


    private bool isOpen = false;
    private int numCompleteObjectives = 0;
    private GameObject currPlayer;
    private InventoryManager inventory;

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < objectives.Length; i++)
        {
            objectives[i].attemptToComplete += attemptToComplete;
            objectives[i].setID(i);
        }
        inventory = FindObjectOfType<InventoryManager>();
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

        if(progressBar.value == 1.0f )
        {
            win();
        }
    }

    private void attemptToComplete(int objectiveID)
    {
        int amountReqd = objectives[objectiveID].getRequiredQuantity();

        // waiting on new inventory to do the checking part, use currPlayer
        for (int i = 0; i < amountReqd; i++)
        {
            inventory.GetSelectedItem(true);
        }


        if(true)
        {
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
