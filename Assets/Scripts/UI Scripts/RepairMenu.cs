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

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < objectives.Length; i++)
        {
            objectives[i].onObjectiveComplete += updateProgress;
        }
    }


    public void toggle(GameObject player)
    {
        if (!isOpen)
        {
            menu.SetActive(true);
            player.GetComponent<PlayerMovement>().enabled = false;
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
        progressBar.value = numCompleteObjectives/objectives.Length;
        if(progressBar.value == 100f )
        {
            win();
        }
    }

    private void win()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("Win");
    }

}
