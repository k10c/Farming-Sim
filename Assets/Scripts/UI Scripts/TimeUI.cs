using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
            // end the game, move to loss screen
        }
    }
}
