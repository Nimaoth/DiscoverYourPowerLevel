using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Custom/Modes/MashSingle")]
public class MashSingleMode : Mode
{
    public string Player1Key;
    public string Player2Key;

    public int LossPerSecond;
    public int GainPerHit;

    public override void OnUpdate(float time)
    {
        if (Input.GetKeyDown(Player1Key)) {
            player1.PowerLevel += GainPerHit;
        } else {
            player1.PowerLevel -= LossPerSecond * time;
        }
        if (Input.GetKeyDown(Player2Key)) {
            player2.PowerLevel += GainPerHit;
        } else {
            player2.PowerLevel -= LossPerSecond * time;
        }
    }
}
