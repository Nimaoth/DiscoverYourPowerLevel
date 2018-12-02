using System;
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

    public ButtonInput[] P1Buttons;
    public ButtonInput[] P2Buttons;

    public override void Start()
    {
        base.Start();
        RandomButtons(P1Buttons, ref Player1Key1, ref Player1Key2);
        RandomButtons(P2Buttons, ref Player2Key1, ref Player2Key2);

        List<ButtonInput> buttons = new List<ButtonInput>((ButtonInput[])Enum.GetValues(typeof(ButtonInput)));


        AssignRandom(ref Player1Key1, buttons);
        AssignRandom(ref Player1Key2, buttons);
        AssignRandom(ref Player2Key1, buttons);
        AssignRandom(ref Player2Key2, buttons);


        ButtonUIManager.instance.SetupButtons1(Player1Key1, Player1Key2);
        ButtonUIManager.instance.SetupButtons2(Player2Key1, Player2Key2);
        ButtonUIManager.instance.SetupDoubleMash((int)Player1Key1, (int) Player1Key2, (int) Player2Key1, (int) Player2Key2 );
        Player1Key = true;
        Player2Key = true;
        

    }

    private void AssignRandom(ref ButtonInput button, List<ButtonInput> list) {
        int i = UnityEngine.Random.Range(0, list.Count);
        button = list[i];
        list.RemoveAt(i);
    }

    private void RandomButtons(ButtonInput[] buttons, ref ButtonInput b1, ref ButtonInput b2) {
        b1 = buttons[UnityEngine.Random.Range(0, buttons.Length)];
        do {
            b2 = buttons[UnityEngine.Random.Range(0, buttons.Length)];
        } while (b2 == b1);
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
