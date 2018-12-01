using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Custom/Modes/MashAlternating")]
public class MashAlternatingMode : Mode {

    public string Player1Key1;
    public string Player1Key2;
    private bool  Player1Key = false;

    public string Player2Key1;
    public string Player2Key2;
    private bool  Player2Key = false;

    public int LossPerSecond;
    public int GainPerHit;

    public override void OnUpdate(float time)
    {
        if (Player1Key && Input.GetKeyDown(Player1Key1)) {
            player1.PowerLevel += GainPerHit;
            Player1Key = !Player1Key;
        }
        if (!Player1Key && Input.GetKeyDown(Player1Key2)) {
            player1.PowerLevel += GainPerHit;
            Player1Key = !Player1Key;
        }

        if (Player2Key && Input.GetKeyDown(Player2Key1)) {
            player2.PowerLevel += GainPerHit;
            Player2Key = !Player2Key;
        }
        if (!Player2Key && Input.GetKeyDown(Player2Key2)) {
            player2.PowerLevel += GainPerHit;
            Player2Key = !Player2Key;
        }

        player1.PowerLevel -= (int)(LossPerSecond * time);
        player2.PowerLevel -= (int)(LossPerSecond * time);
    }

}
