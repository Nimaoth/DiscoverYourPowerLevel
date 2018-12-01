using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {

    public static EffectManager Instance;

    public Transform EffectCanvas;


    public Effect[] NegEffects;
    public Effect[] PosEffects;
    public Effect[] SuperPosEffects;

    private void Awake() {
        Instance = this;
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

}
