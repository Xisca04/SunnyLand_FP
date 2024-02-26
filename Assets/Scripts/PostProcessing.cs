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
    private Vignette _vignette;

    private void Awake()
    {
        _volume = GetComponent<Volume>();
    }

    private void Start()
    {
        _volume.profile.TryGet(out _vignette); // busca y encuentra la vignette
        _vignette.active = true;
    }

    public IEnumerator Desactive() // Descative the vignette
    {
        yield return new WaitForSeconds(0.1f);
        _vignette.active = false;
    }

    public IEnumerator Active() // Active the vignette
    {
        _vignette.active = true;
        yield return new WaitForSeconds(1f);
        _vignette.intensity.value = 1f;
        _vignette.color.value = Color.red;
    }
}
