using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    // Countdown for the final and the bonus level

    public static CountdownTimer Instance { get; private set; }  // Singleton

    public float timeLeft = 10f;
    [SerializeField] private TextMeshProUGUI timerText;
    private bool timerOn = false;

    public float timeToAdd = 5f;

    private void Awake() // Singleton
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one Instance Timer");
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

            if (timeLeft < 5)
            {
                timerText.color = Color.red;
            }
        }
    }
}
