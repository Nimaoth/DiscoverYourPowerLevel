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
    public int CurrentModeIndex = 0;

    [SerializeField]
    private Mode CurrentMode = null;

    public void Start() {
        foreach (var mode in Modes) {
            mode.Mode.Start();
        }

        AudioSource = ClipManager.Instance.ClipAudioSource;
        AudioSource.clip = AudioClip;
        AudioSource.Play();
    }

    public void OnUpdate(float time) {
        float progress = (float)AudioSource.timeSamples / AudioClip.samples * AudioClip.length;

        if (CurrentModeIndex < Modes.Length) {
            var modeTrigger = Modes[CurrentModeIndex];
            if (progress >= modeTrigger.StartTime) {
                CurrentModeIndex++;
                CurrentMode = modeTrigger.Mode;
            }
        }

        if (CurrentMode != null) {
            CurrentMode.OnUpdate(time);
        }
    }

}
