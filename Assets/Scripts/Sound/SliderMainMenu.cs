using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMainMenu : MonoBehaviour
{
    // Slider set music of the background music of the different levels

    [SerializeField] private Slider sliderBackgroundMusic;
    [SerializeField] private GameObject cam;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = cam.GetComponent<AudioSource>(); 

        // Establece el valor del slider al volumen actual de la música
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("MusicVolume");
            _audioSource.volume = savedVolume;
            sliderBackgroundMusic.value = savedVolume;
        }
        else
        {
            _audioSource.volume = 0.5f; // O cualquier otro valor por defecto
            sliderBackgroundMusic.value = 0.5f;
        }
    }


    public void VolumeMusic(float value)
    {
        _audioSource.volume = value;  // = el objeto que ya tiene acceso el audiosource, ahora accedemos a su componente volumen con la variable creada
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

}
