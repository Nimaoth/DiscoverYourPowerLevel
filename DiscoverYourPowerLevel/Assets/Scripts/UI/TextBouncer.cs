using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBouncer : MonoBehaviour {

    public float maxScale;
    public float bounceSpeed = 1;

    private bool isBoucingUp;
    private float currentScale;

    void Start () {
        currentScale = 1;
        isBoucingUp = false;
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

    public void Bounce() {
        isBoucingUp = true;
    }
}
