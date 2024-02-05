using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    // Countdown for the final and the bonus level

    [SerializeField] private float timeLeft = 10f;
    [SerializeField] private TextMeshProUGUI timerText;
    private bool timerOn = false;

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
