using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// Aidan

public class TimeUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timeRemaining;
    [SerializeField]
    private int hoursWorthOfRations;
    private int hoursRemaining;

    // Start is called before the first frame update
    void Start()
    {
        // subscribe to hour changing
        TimeManager.OnHourChanged += UpdateTime;
        hoursRemaining = hoursWorthOfRations;
        timeRemaining.text = $"Hours remaining: {hoursRemaining.ToString()}";
    }

    void UpdateTime()
    {
        hoursRemaining--;
        timeRemaining.text = $"Hours remaining: {hoursRemaining.ToString()}";
        if (hoursRemaining == 0){
            Time.timeScale = 0.0f;
            SceneManager.LoadScene("Loss");
        }
    }
}
