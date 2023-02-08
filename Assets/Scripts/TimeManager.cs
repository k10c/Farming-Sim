using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    // new actions for planned interaction with listeners(observers)
    public static Action OnMinuteChanged;
    public static Action OnHourChanged;

    // current minute
    public static int Minute { get; private set; }
    // current hour
    public static int Hour { get; private set; }
   
    // may add days for tracking deadline (possible win con)

    private float minuteToRealTime = 0.5f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        Minute = 0;
        Hour = 0;
        timer = minuteToRealTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Minute++;

            // notify listeners (if any) that the minute has changed
            OnMinuteChanged?.Invoke();
            
            if(Minute >= 60)
            {
                Hour++;

                // notify listeners (if any) that the hour has changed
                OnHourChanged?.Invoke();

                // if Hour >= 24 ?
                Minute = 0;
            }

            timer = minuteToRealTime;
        }
    }
}
