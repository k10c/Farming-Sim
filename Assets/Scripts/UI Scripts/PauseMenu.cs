using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    
    // variable to keep track of whether or not the game is paused; default false
    private static bool GameIsPaused = false;
    // 
    [SerializeField]
    private GameObject pauseMenuUI;

    private void Start()
    {
        GameIsPaused = false;
    }

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

    // close pause menu and unfreeze time
    void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    // freeze time and open pause menu
    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
