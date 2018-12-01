using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {


    public GameObject[] NegEffects;
    public GameObject[] PosEffects;
    public GameObject[] SuperPosEffects;

    private void PlayEffect(int effect, GameObject[] EffectType)
    {
        GameObject prefab = EffectType[effect];
        Instantiate(prefab);
    }

    private void PlayNegEffct()
    {
        GameObject prefab = NegEffects[Random.Range(0, NegEffects.Length - 1)];
        Instantiate(prefab);
    }

    private void PlayPosEffct()
    {
        GameObject prefab = PosEffects[Random.Range(0, PosEffects.Length - 1)];
        Instantiate(prefab);
    }

    private void PlaySuperPosEffct()
    {
        GameObject prefab = SuperPosEffects[Random.Range(0, SuperPosEffects.Length - 1)];
        Instantiate(prefab);
    }

}
