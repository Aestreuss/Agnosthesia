using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeValue = 60; //the amount of time it will be counting down from 
    public TextMeshProUGUI timerText;
    public bool timerIsRunning = false;

    private void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeValue > 0)
            {
                //if time value is greater than 0 it will countdown
                timeValue -= Time.deltaTime;
            }
            else
            {
                timeValue = 0;
                timerIsRunning = false;
            }

            DisplayTime(timeValue);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        else if (timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }


        float minutes = Mathf.FloorToInt(timeToDisplay / 60); //floorToInt is what rounds it down and for this it's to the closest minute
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); //same as above but instead to the closest seconds 

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); 
        //the values within the quotations are parameters, the 0 and 1 in the beginning of both refer to whether you are using minutes or seconds.
        //the :00 tells you how to format the values in this case being a 2 digit number
    }
}
