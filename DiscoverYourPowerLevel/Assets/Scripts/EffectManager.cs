using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {

    public static EffectManager Instance;

    public Transform EffectCanvas;


    public Effect[] NegEffects;
    public Effect[] PosEffects;
    public Effect[] SuperPosEffects;
    public Effect[] NegAudioEffects;
    public Effect[] PosAudioEffects;

    private void Awake() {
        Instance = this;
    }

    public void PlayEffect(Effect effect)
    {
        //Todo
        effect.Spawn(Vector3.zero);
    }

    public void PlayNegEffect()
    {
        var effect = NegEffects[Random.Range(0, NegEffects.Length)];
        effect.Spawn();
    }

    public void PlayPosEffect()
    {
        var effect = PosEffects[Random.Range(0, PosEffects.Length)];
        effect.Spawn();
    }

    public void PlaySuperPosEffect()
    {
        var effect = SuperPosEffects[Random.Range(0, SuperPosEffects.Length)];
        effect.Spawn();
    }

    public void PlayNegAudioEffect()
    {
        var effect = NegAudioEffects[Random.Range(0, NegAudioEffects.Length)];
        effect.Spawn();
    }

    public void PlayPosAudioEffect()
    {
        var effect = PosAudioEffects[Random.Range(0, PosAudioEffects.Length)];
        effect.Spawn();
    }
}
