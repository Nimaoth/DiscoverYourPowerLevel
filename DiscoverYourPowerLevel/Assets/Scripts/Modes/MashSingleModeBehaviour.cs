using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MashSingleModeBehaviour : ModeBehaviour
{
    public ButtonInput Player1Key;
    public ButtonInput Player2Key;
    
    public int GainPerHit;

    public override void OnUpdate(float time)
    {
        int p1key = (int)Player1Key;
        int p2key = (int)Player2Key;
        if (Input.GetKeyDown(p1key.ToString())) {
            player1.PowerLevel += GainPerHit;
        }
        if (Input.GetKeyDown(p2key.ToString())) {
            player2.PowerLevel += GainPerHit;
        }
    }
}
