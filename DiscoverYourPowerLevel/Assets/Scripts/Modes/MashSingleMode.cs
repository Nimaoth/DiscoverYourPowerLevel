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

    private float secondTimer = 0;

    public override void OnUpdate(float time)
    {
        if (Input.GetKeyDown(Player1Key)) {
            player1.PowerLevel += GainPerHit;
        }
        if (Input.GetKeyDown(Player2Key)) {
            player2.PowerLevel += GainPerHit;
        }

        player1.PowerLevel -= (int)(LossPerSecond * time);
        player2.PowerLevel -= (int)(LossPerSecond * time);

        secondTimer += time;
        if (secondTimer >= 1) {
            secondTimer -= 1;
            // player1.PowerLevel -= LossPerSecond;
            // player2.PowerLevel -= LossPerSecond;
        }
    }
}
