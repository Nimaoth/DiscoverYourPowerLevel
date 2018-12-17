using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Alternating3ModeBehaviour : ModeBehaviour {

    public ButtonInput Player1Key1;
    public ButtonInput Player1Key2;
    public ButtonInput Player1Key3;

    private int Player1Key = 0;

    public ButtonInput Player2Key1;
    public ButtonInput Player2Key2;
    public ButtonInput Player2Key3;

    private int Player2Key = 0;

    public int LossPerSecond;
    public int GainPerHit;

    public override void OnStart()
    {
        Player1Key = 0;
        Player2Key = 0;
    }


    public override void OnUpdate(float time)
    {
        int p1key1 = (int)Player1Key1;
        int p1key2 = (int)Player1Key2;
        int p1key3 = (int)Player1Key3;
        int p2key1 = (int)Player2Key1;
        int p2key2 = (int)Player2Key2;
        int p2key3 = (int)Player2Key2;

        if (Player1Key == 0 && Input.GetKeyDown(p1key1.ToString())) {
            player1.PowerLevel += GainPerHit;
            Player1Key = (Player1Key + 1) % 3;
        }
        if (Player1Key == 1 && Input.GetKeyDown(p1key2.ToString())) {
            player1.PowerLevel += GainPerHit;
            Player1Key = (Player1Key + 1) % 3;
        }
        if (Player1Key == 2 && Input.GetKeyDown(p1key3.ToString())) {
            player1.PowerLevel += GainPerHit;
            Player1Key = (Player1Key + 1) % 3;
        }

        if (Player2Key == 0 && Input.GetKeyDown(p2key1.ToString())) {
            player2.PowerLevel += GainPerHit;
            Player2Key = (Player2Key+1)%3;
        }
        if (Player2Key == 1 && Input.GetKeyDown(p2key2.ToString())) {
            player2.PowerLevel += GainPerHit;
            Player2Key = (Player2Key+1)%3;
        }
        if (Player2Key == 2 && Input.GetKeyDown(p2key3.ToString())) {
            player2.PowerLevel += GainPerHit;
            Player2Key = (Player2Key+1)%3;
        }

        player1.PowerLevel -= LossPerSecond * time;
        player2.PowerLevel -= LossPerSecond * time;
    }
}
