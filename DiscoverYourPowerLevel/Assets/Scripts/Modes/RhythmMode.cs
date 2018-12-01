using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Modes/RhythmMode")]
public class RhythmMode : Mode {
    public string Player1Key;
    public string Player2Key;

    public int LossPerHit;
    public int GainPerHit;

    public float bpm;
    public float timingAccuracy;
    public float tickOffset;
    public float klickOffset;
    public float timer;

    public AudioClip testSound;

    public override void Start()
    {
        base.Start();
        timer = tickOffset;
    }

    float lastTimer = 0;

    public override void OnUpdate(float time)
    {
        float progress = AudioSource.time;

        // time between beats
        float tbb = 60 / bpm;


        timer = (progress + tickOffset) % tbb;
        if (Mathf.Abs(timer - lastTimer) > 0.5f * tbb) {
            EffectManager.Instance.PlayPosEffect();
            AudioSource.PlayClipAtPoint(testSound, Vector3.zero);
        }
        lastTimer = timer;

        var timer2 = timer + klickOffset;
        if (Input.GetKeyDown(Player1Key)) {
            if (timer2 < timingAccuracy || timer2 > tbb - timingAccuracy)
                player1.PowerLevel += GainPerHit;
            else
                player1.PowerLevel -= LossPerHit;
        }
        if (Input.GetKeyDown(Player2Key)) {
            if (timer2 < timingAccuracy || timer2 > tbb - timingAccuracy)
                player2.PowerLevel += GainPerHit;
            else
                player2.PowerLevel -= LossPerHit;
        }
    }
}
