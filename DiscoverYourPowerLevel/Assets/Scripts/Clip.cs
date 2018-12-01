using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ModeTrigger {
    public float StartTime;
    public Mode Mode;
}

[Serializable]
public struct EffectTrigger {
    public float StartTime;
    public Effect Effect;
}

[CreateAssetMenu(menuName="Custom/Clip")]
public class Clip : ScriptableObject {

    public bool Done = false;

    public AudioSource AudioSource;
    public AudioClip AudioClip;


    //Modes
    public ModeTrigger[] Modes;

    [SerializeField]
    private int CurrentModeIndex = -1;

    [SerializeField]
    private Mode CurrentMode = null;

    //ScreenEffects
    private EffectManager EffectManager;
    public EffectTrigger[] Effects;

    [SerializeField]
    private int CurrentEffectIndex = 0;



    public void Start() {
        CurrentModeIndex = -1;
        CurrentMode = null;
        StartNextMode();

        CurrentEffectIndex = 0;
        EffectManager = GameObject.FindGameObjectWithTag("EffectManager").GetComponent<EffectManager>();

        AudioSource = ClipManager.Instance.ClipAudioSource;
        AudioSource.clip = AudioClip;
        AudioSource.Play();
    }

    public void OnUpdate(float time) {
        float progress = (float)AudioSource.timeSamples / AudioClip.samples * AudioClip.length;

        //Switch to next Mode
        if (CurrentModeIndex + 1 < Modes.Length) {
            var modeTrigger = Modes[CurrentModeIndex + 1];
            if (progress >= modeTrigger.StartTime) {
                StartNextMode();
            }
        }

        //Update Mode
        if (CurrentMode != null) {
            CurrentMode.OnUpdate(time);
        }

        //Play Effect
        if(CurrentEffectIndex != -1)
        {
            var effectTrigger = Effects[CurrentEffectIndex];
            if (progress >= effectTrigger.StartTime) {
                PlayEffect(effectTrigger.Effect);
            }
        }

    }

    private void StartNextMode() {
        CurrentMode = null;
        CurrentModeIndex++;
        if (CurrentModeIndex < Modes.Length) {
            CurrentMode = Modes[CurrentModeIndex].Mode;
            CurrentMode.Start();
            CurrentMode.AudioSource = AudioSource;
        }
    }

    private void PlayEffect(Effect effect) {  
        Debug.Log("Effect played");
        if (CurrentEffectIndex < Effects.Length) {
            // Call EffectManager
            EffectManager.PlayEffect(effect);
            CurrentEffectIndex += 1;
        }
        if (CurrentEffectIndex == Effects.Length)
        {
            CurrentEffectIndex = -1;
        }
        
    }

}
