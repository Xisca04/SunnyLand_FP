using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimpleTimer : MonoBehaviour
{
    // Simple Timer version from the Countdown Timer
    // Time for the Final Chest Scene and for the Minigame

    public static SimpleTimer Instance { get; private set; }  // Singleton

    // Simple Timer
    public float timeLeft = 60f;
    private bool timerOn = false;

    // UI
    [SerializeField] private TextMeshProUGUI timerText;
    

    private void Awake() // Singleton
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one Instance Simple Timer");
        }

        Instance = this;
    }

    private void Start()
    {
        timerOn = true;
    }

    private void Update()
    {
        CountDown();
    }

    private void CountDown() // Timer
    {
        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                timerText.text = "" + timeLeft.ToString("f0");
            }

            if (timeLeft <= 0)
            {
                timeLeft = 0;
                timerOn = false;
            }

            if (timeLeft < 5) // Turn to red the timer text
            {
                timerText.color = Color.red;
            }
        }
    }
}
