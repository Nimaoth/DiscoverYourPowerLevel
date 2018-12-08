using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarMultiplicator : MonoBehaviour {

    public Player player;
    public TMP_Text text;

    public bool left = true;

    void Start () {
        if (text != null) text = GetComponentInChildren<TMP_Text>();
    }

    public void UpdateText(Player p) {
        string s = p.Multiplier.ToString();
        if (left) s = $"x{s}";
        else s = $"{s}x";
        text.text = s;
    }
}
