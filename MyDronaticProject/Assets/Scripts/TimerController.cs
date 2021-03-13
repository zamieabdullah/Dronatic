using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    private float elapsedTime;
    public bool timerIsRunning = false;

    public Text timeText;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        elapsedTime = 0;
    }

    void Update()
    {
        if (timerIsRunning) {
            elapsedTime += Time.deltaTime;
        }
        displayTimer();
    }

    private void displayTimer() 
    {
        float minutes = Mathf.FloorToInt(elapsedTime / 60);
        float seconds = Mathf.FloorToInt(elapsedTime % 60);

        timeText.text = string.Format("Survived: {0:00}:{1:00}", minutes, seconds);

    }



}