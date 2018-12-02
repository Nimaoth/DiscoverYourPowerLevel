using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Custom/Modes/MashSingle")]
public class MashSingleMode : Mode
{
    public ButtonInput Player1Key;
    public ButtonInput Player2Key;

    public int LossPerSecond;
    public int GainPerHit;

    public override void OnUpdate(float time)
    {
        int p1key = (int)Player1Key;
        int p2key = (int)Player2Key;
        if (Input.GetKeyDown(p1key.ToString())) {
            player1.PowerLevel += GainPerHit;
        } else {
            player1.PowerLevel -= LossPerSecond * time;
        }
        if (Input.GetKeyDown(p2key.ToString())) {
            player2.PowerLevel += GainPerHit;
        } else {
            player2.PowerLevel -= LossPerSecond * time;
        }
    }
}
