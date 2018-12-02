using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonInput
{
    RED,
    BLACK,
    WHITE,
    GREEN,
    YELLOW,
    BLUE
};

[CreateAssetMenu(menuName = "Custom/Modes/RhythmMode")]
public class RhythmMode : Mode {
    public ButtonInput Player1Key;
    public ButtonInput Player2Key;

    public int LossPerHit;
    public int GainPerHit;

    public float bpm;
    public float timingAccuracy;
    public float tickOffset;
    public float klickOffset;
    public float timer;

    public AudioClip testSound;

    public Effect tickEffect;

    public override void Start()
    {
        base.Start();
        timer = tickOffset;
        ButtonUIManager.instance.SetupRhythm((int)Player1Key, (int) Player2Key);
        ButtonUIManager.instance.SetupRhythmButtons();
    }

    float lastTimer = 0;

    private bool p1canHit = true;
    private bool p2canHit = true;

    public override void OnUpdate(float time)
    {
        float progress = AudioSource.time;

        // time between beats
        float tbb = 60 / bpm;


        timer = (progress + tickOffset) % tbb;
        if (Mathf.Abs(timer - lastTimer) > 0.5f * tbb) {
            // EffectManager.Instance.PlayPosEffect();
            AudioSource.PlayClipAtPoint(testSound, Vector3.zero);

            if (tickEffect != null) {
                tickEffect.Spawn();
            }
        }
        lastTimer = timer;

        var timer2 = (timer + klickOffset) % tbb;
        int p1key = (int)Player1Key;
        int p2key = (int)Player2Key;

        // if (Input.GetKeyDown(p1key.ToString())) {
        //     if ((timer2 < timingAccuracy || timer2 > tbb - timingAccuracy) && p1canHit)
        //     {
        //         player1.PowerLevel += GainPerHit;
        //         ButtonUIManager.instance.ProgressPlayer1();
        //         p1canHit = false;
        //     }
        //     else
        //         player1.PowerLevel -= LossPerHit;
        // }

        // if (Input.GetKeyDown(p2key.ToString())) {
        //     if ((timer2 < timingAccuracy || timer2 > tbb - timingAccuracy) && p2canHit)
        //     {
        //         player2.PowerLevel += GainPerHit;
        //         ButtonUIManager.instance.ProgressPlayer2();
        //         p2canHit = false;
        //     }

        //     else
        //         player2.PowerLevel -= LossPerHit;
        // }

        if (timer2 < timingAccuracy || timer2 > tbb - timingAccuracy) {
            if (Input.GetKeyDown(p1key.ToString()) && p1canHit) {
                player1.PowerLevel += GainPerHit;
                ButtonUIManager.instance.ProgressPlayer1();
                p1canHit = false;
            }
            if (Input.GetKeyDown(p2key.ToString()) && p2canHit) {
                player2.PowerLevel += GainPerHit;
                ButtonUIManager.instance.ProgressPlayer2();
                p2canHit = false;
            }
        } else {
            p1canHit = true;
            p2canHit = true;
            if (Input.GetKeyDown(p1key.ToString())) {
                player1.PowerLevel -= LossPerHit;
            }
            if (Input.GetKeyDown(p2key.ToString())) {
                player2.PowerLevel -= LossPerHit;
            }
        }

        var timer3 = (progress + 0) % tbb;
        UIManager.Instance.HitCirclePlayer1.openness = 1 - (timer3 / tbb);
        UIManager.Instance.HitCirclePlayer2.openness = 1 - (timer3 / tbb);
    }
}
