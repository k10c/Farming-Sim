using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by Aiden and Ben
//Controls the pause menu. Needed a unique version for multiplayer that didn't stop time.

public class OnlinePauseMenu : MonoBehaviour
{
    
    // variable to keep track of whether or not the game is paused; default false
    private static bool GameIsPaused = false;
    // The UI that is being activated / deactivated
    [SerializeField]
    private GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        // if the player(s) press esc or p, pauses or unpauses the game dep. on curr state
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    // close pause menu
    void Resume(){
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }

    // open pause menu
    void Pause(){
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
    }
}
