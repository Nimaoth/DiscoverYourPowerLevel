using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipManager : MonoBehaviour {

    public static ClipManager Instance;

    public Clip[] Clips;

    private int CurrentClipIndex = -1;
    private Clip currentClip = null;

    public AudioSource ClipAudioSource;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        ClipAudioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        if (currentClip == null) {
            StartNextClip();
        }

        if (currentClip != null) {
            currentClip.OnUpdate(Time.deltaTime);
            if (currentClip.Done) {
                StartNextClip();
            }
        }
    }

    private void StartNextClip() {
        currentClip = null;
        CurrentClipIndex++;
        if (CurrentClipIndex < Clips.Length) {
            currentClip = Clips[CurrentClipIndex];
            currentClip.Start();
        }
    }

}
