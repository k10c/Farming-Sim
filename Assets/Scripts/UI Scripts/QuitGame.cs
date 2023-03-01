using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // call this to quit out, can implement autosaving here 
    public void Quit()
    {
        Application.Quit();
    }
}
