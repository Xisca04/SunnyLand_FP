using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundAudioClips : MonoBehaviour
{
    public static SoundAudioClips Instance { get; private set; }  // Singleton


    [Serializable] public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }

    public SoundAudioClip[] soundAudioClipArray;

    private void Awake() // Singleton
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one Instance SoundAudioClips");
        }

        Instance = this;
    }
}
