using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// WRITTEN BY: Aidan 

public class ChangeScene : MonoBehaviour
{
    // Switches to the scene in the build with the given scene ID
   public void MoveToScene(int SceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneID);
    }
}
