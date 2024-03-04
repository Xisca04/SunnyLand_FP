using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessing : MonoBehaviour
{
    // Vignette for the Final Level

    // Post-Processing
    private Volume _volume;
    [SerializeField] private Vignette _vignette;

    // Variables
    private int timeIsRunningOut = 5;
    private int plentyOfTime = 6;

    private void Awake()
    {
        _volume = GetComponent<Volume>();
    }

    private void Start()
    {
        _volume.profile.TryGet(out _vignette); // Search and find the vignette
        _vignette.active = false;
    }

    // Activates or deactivates the vignette according to the Countdown Timer
    private void Update()
    {
        if(CountdownTimer.Instance.timeLeft <= timeIsRunningOut) // Timer less than 5 seconds - ACTIVATE
        {
            _vignette.active = true;
        }
        else if(CountdownTimer.Instance.timeLeft >= plentyOfTime || CountdownTimer.Instance.timeLeft == 0) // Timer more than 6 seconds or equal to 0 - DEACTIVATE
        {
            _vignette.active = false;
        }
        else
        {
            _vignette.active = false;
        }
   
    }
}
