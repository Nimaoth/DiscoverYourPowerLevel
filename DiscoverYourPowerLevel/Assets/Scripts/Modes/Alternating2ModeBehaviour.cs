using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Alternating2ModeBehaviour : ModeBehaviour {

    public bool RandomizeButtons = true;
    public ButtonInput Player1Key1;
    public ButtonInput Player1Key2;
    private bool  Player1Key = false;

    public ButtonInput Player2Key1;
    public ButtonInput Player2Key2;
    private bool  Player2Key = false;

    public int GainPerHit;

    public ButtonInput[] P1Buttons;
    public ButtonInput[] P2Buttons;


    public override void OnStart()
    {
        if (RandomizeButtons) {
            List<ButtonInput> buttons = new List<ButtonInput>((ButtonInput[])Enum.GetValues(typeof(ButtonInput)));
            AssignRandom(ref Player1Key1, buttons);
            AssignRandom(ref Player1Key2, buttons);
            AssignRandom(ref Player2Key1, buttons);
            AssignRandom(ref Player2Key2, buttons);
        }

        var p1 = UI.transform.Find("p1");
        foreach (var c in p1.GetChildren()) c.gameObject.SetActive(false);
        p1.transform.Find(Player1Key1.ToString()).gameObject.SetActive(true);
        p1.transform.Find(Player1Key2.ToString()).gameObject.SetActive(true);
        
        var p2 = UI.transform.Find("p2");
        foreach (var c in p2.GetChildren()) c.gameObject.SetActive(false);
        p2.transform.Find(Player2Key1.ToString()).gameObject.SetActive(true);
        p2.transform.Find(Player2Key2.ToString()).gameObject.SetActive(true);
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
            Player1Key = !Player1Key;
        }
        if (!Player1Key && Input.GetKeyDown(p1key2.ToString())) {
            player1.PowerLevel += GainPerHit;
            Player1Key = !Player1Key;
        }

        if (Player2Key && Input.GetKeyDown(p2key1.ToString())) {
            player2.PowerLevel += GainPerHit;
            Player2Key = !Player2Key;
        }
        if (!Player2Key && Input.GetKeyDown(p2key2.ToString())) {
            player2.PowerLevel += GainPerHit;
            Player2Key = !Player2Key;
        }
    }

}
