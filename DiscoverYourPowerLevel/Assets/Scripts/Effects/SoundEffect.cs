using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Effect/SoundEffect")]
public class SoundEffect : Effect
{
    public AudioClip soundClip;

    public override void Spawn(Vector3 location)
    {
        SoundEffectPlayer.instance.PlaySound(soundClip);
    }
}