using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGrow : MonoBehaviour {

    public ButtonInput input;

    public float min = 0.7f;
    public float max = 1.3f;


    [SerializeField]
    private bool isBoucingUp;
    [SerializeField]
    private float currentScale;

    [SerializeField]
    private float bounceSpeed = 1;

    private new RectTransform transform;

    void Start () {
        currentScale = min;
        isBoucingUp = false;
        transform = GetComponent<RectTransform>();
    }
    
    void Update () {
        if (Input.GetKeyDown(((int)input).ToString())) {
            isBoucingUp = true;
        }

        if (isBoucingUp) {
            currentScale += bounceSpeed * Time.deltaTime;
        } else {
            currentScale -= bounceSpeed * Time.deltaTime;
        }

        if (currentScale < 1) {
            currentScale = 1;
        }
        else if (currentScale >= max) {
            currentScale = max;
            isBoucingUp = false;
        }

        transform.localScale = new Vector3(currentScale, currentScale, currentScale);
    }
}
