using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipManager : MonoBehaviour {


    public Clip[] Clips;

    private int CurrentClipIndex = -1;
    private Clip currentClip = null;

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
