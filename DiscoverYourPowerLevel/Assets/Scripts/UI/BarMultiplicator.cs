using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarMultiplicator : MonoBehaviour {

    public Player player;
    public TextMeshPro text;

    public bool left = true;
    public float maxScale;
    public float bounceSpeed = 1;


    private bool isBoucingUp;
    private float currentScale;


    void Start () {
        if (text != null) text = GetComponentInChildren<TextMeshPro>();
        currentScale = 1;
        isBoucingUp = false;

        player.OnMultiplierIncreased.AddListener(level => {
            string s = level.ToString();
            if (left) s = $"x{s}";
            else s = $"{s}x";
            text.text = s;
            isBoucingUp = true;
        });
    }

    void Update () {
        if (isBoucingUp) {
            currentScale += bounceSpeed * Time.deltaTime;
        } else {
            currentScale -= bounceSpeed * Time.deltaTime;
        }

        if (currentScale < 1) {
            currentScale = 1;
        }
        else if (currentScale >= maxScale) {
            currentScale = maxScale;
            isBoucingUp = false;
        }

        transform.localScale = new Vector3(currentScale, currentScale, currentScale);
    }
}
