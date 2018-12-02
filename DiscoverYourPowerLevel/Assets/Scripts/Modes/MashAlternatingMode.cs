using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Custom/Modes/MashAlternating")]
public class MashAlternatingMode : Mode {

    public ButtonInput Player1Key1;
    public ButtonInput Player1Key2;
    private bool  Player1Key = false;

    public ButtonInput Player2Key1;
    public ButtonInput Player2Key2;
    private bool  Player2Key = false;

    public int LossPerSecond;
    public int GainPerHit;

    public override void Start()
    {
        base.Start();
        ButtonUIManager.instance.SetupDoubleMash((int)Player1Key1, (int) Player1Key2, (int) Player2Key1, (int) Player2Key2 );
        Player1Key = true;
        Player2Key = true;

    }
    public override void OnUpdate(float time)
    {
        int p1key1 = (int)Player1Key1;
        int p1key2 = (int)Player1Key2;
        int p2key1 = (int)Player2Key1;
        int p2key2 = (int)Player2Key2;

        if (Player1Key && Input.GetKeyDown(p1key1.ToString())) {
            player1.PowerLevel += GainPerHit;
            ButtonUIManager.instance.ProgressPlayer1();
            Player1Key = !Player1Key;
        }
        if (!Player1Key && Input.GetKeyDown(p1key2.ToString())) {
            player1.PowerLevel += GainPerHit;
            ButtonUIManager.instance.ProgressPlayer1();
            Player1Key = !Player1Key;
        }

        if (Player2Key && Input.GetKeyDown(p2key1.ToString())) {
            player2.PowerLevel += GainPerHit;
            ButtonUIManager.instance.ProgressPlayer2();
            Player2Key = !Player2Key;
        }
        if (!Player2Key && Input.GetKeyDown(p2key2.ToString())) {
            player2.PowerLevel += GainPerHit;
            ButtonUIManager.instance.ProgressPlayer2();
            Player2Key = !Player2Key;
        }

        player1.PowerLevel -= LossPerSecond * time;
        player2.PowerLevel -= LossPerSecond * time;
    }

}
