using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Effect/ScreenShake")]
public class ScreenShakeEffect : Effect {

    public float Insensity = 2;
    public float Decay = 0.2f;

    public override void Spawn(Vector3 location)
    {
        GameManager.Instance.CameraShake.Shake(Insensity, Decay);
    }
}
