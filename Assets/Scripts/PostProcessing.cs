using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessing : MonoBehaviour
{
    // Pasar c# al script el timer
    // Vignette

    private Volume _volume;
    [SerializeField] private Vignette _vignette;

    private void Awake()
    {
        _volume = GetComponent<Volume>();
    }

    private void Start()
    {
        _volume.profile.TryGet(out _vignette); // busca y encuentra la vignette
        _vignette.active = false;
    }

    private void Update()
    {
        if(CountdownTimer.Instance.timeLeft <= 5 || SimpleTimer.Instance.timeLeft <= 5)
        {
            _vignette.active = true;
        }
        else if (CountdownTimer.Instance.timeLeft == 0 || SimpleTimer.Instance.timeLeft == 0) // no funciona
        {
            _vignette.active = false;
            Debug.Log("desactivar");
        }
        else
        {
            _vignette.active = false;
        }
   
    }
}
