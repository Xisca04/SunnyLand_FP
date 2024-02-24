using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //sound manager
    public enum Sound
    {
        Cherry,
        Gem,
        PU_Path,
        PU_Countdown_On,
        PU_Countdown_Off,
        Enemy_Death,
        Run,
        Jump,
        Die
    }

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = this.gameObject.AddComponent<AudioSource>();
    }

    public void PlaySound(Sound sound)
    {
        audioSource.PlayOneShot(GetAudioClipFromSound(sound));
    }

    private AudioClip GetAudioClipFromSound(Sound sound)
    {
        foreach (SoundAudioClips.SoundAudioClip soundAudioClip in SoundAudioClips.Instance.soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }

        Debug.LogError("Sound" + sound + "not found");
        return null;
    }


}
