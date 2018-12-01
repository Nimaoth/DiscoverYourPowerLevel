using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour {

    public static SoundEffectPlayer instance;
    AudioSource audiosource;
    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        instance = this;
    }

    public void PlaySound(AudioClip clip)
    {
        audiosource.clip = clip;
        audiosource.Play();
    }
}
