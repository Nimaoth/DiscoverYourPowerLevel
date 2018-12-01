using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ModeTrigger {
    public float StartTime;
    public Mode Mode;
}

[CreateAssetMenu(menuName="Custom/Clip")]
public class Clip : ScriptableObject {

    public bool Done = false;

    public AudioSource AudioSource;
    public AudioClip AudioClip;

    public ModeTrigger[] Modes;

    [SerializeField]
    private int CurrentModeIndex = -1;

    [SerializeField]
    private Mode CurrentMode = null;

    public void Start() {
        CurrentModeIndex = -1;
        CurrentMode = null;
        StartNextMode();

        AudioSource = ClipManager.Instance.ClipAudioSource;
        AudioSource.clip = AudioClip;
        AudioSource.Play();
    }

    public void OnUpdate(float time) {
        float progress = (float)AudioSource.timeSamples / AudioClip.samples * AudioClip.length;

        if (CurrentModeIndex + 1 < Modes.Length) {
            var modeTrigger = Modes[CurrentModeIndex + 1];
            if (progress >= modeTrigger.StartTime) {
                StartNextMode();
            }
        }

        if (CurrentMode != null) {
            CurrentMode.OnUpdate(time);
        }
    }

    private void StartNextMode() {
        CurrentMode = null;
        CurrentModeIndex++;
        if (CurrentModeIndex < Modes.Length) {
            CurrentMode = Modes[CurrentModeIndex].Mode;
            CurrentMode.Start();
        }
    }

}
