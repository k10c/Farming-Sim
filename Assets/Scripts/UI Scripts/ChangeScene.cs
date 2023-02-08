using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Switches to the scene in the build with the given scene ID
   public void MoveToScene(int SceneID)
    {
        SceneManager.LoadScene(SceneID);
    }
}
