using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Custom/Effect/ShatterEffect")]
public class ShatterEffect : Effect
{
    public override void Spawn(Vector3 location)
    {
        ShatterRefraction.Instance.ShatterScreen();
    }
}
