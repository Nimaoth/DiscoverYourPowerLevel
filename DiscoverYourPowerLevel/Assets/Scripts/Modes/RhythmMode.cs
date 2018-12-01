using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Modes/RhythmMode")]
public class RhythmMode : Mode {
    public string Player1Key;
    public string Player2Key;

    public int LossPerHit;
    public int GainPerHit;

    public float tactTime;
    public float timingAccuracy;
    public float tickOffset;
    public float timer;

    public AudioClip testSound;
    public override void Start()
    {
        base.Start();
        timer = tickOffset;
    }

    public override void OnUpdate(float time)
    {
        if(timer <= 0)
        {
            EffectManager.Instance.PlayPosEffect();
            AudioSource.PlayClipAtPoint(testSound, Vector3.zero);
            timer += tactTime;
        }
        if (Input.GetKeyDown(Player1Key)) {
            if (timer < timingAccuracy || timer > tactTime - timingAccuracy)
                player1.PowerLevel += GainPerHit;
            else
                player1.PowerLevel -= LossPerHit;
        }
        if (Input.GetKeyDown(Player2Key)) {
            if (timer < timingAccuracy || timer > tactTime - timingAccuracy)
                player2.PowerLevel += GainPerHit;
            else
                player2.PowerLevel -= LossPerHit;
        }

        timer -= time;
    }
}
