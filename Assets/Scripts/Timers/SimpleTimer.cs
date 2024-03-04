using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimpleTimer : MonoBehaviour
{
    // Simple Timer

    public static SimpleTimer Instance { get; private set; }  // Singleton

    public float timeLeft = 60f;
    [SerializeField] private TextMeshProUGUI timerText;
    private bool timerOn = false;

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

            if (timeLeft < 5)
            {
                timerText.color = Color.red;
            }
        }
    }
}
