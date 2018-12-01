using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBouncer : MonoBehaviour {

    public float maxScale;
    public float bounceSpeed = 1;

    public Player Player;

    [SerializeField]
    private Text text;


    [SerializeField]
    private bool isBoucingUp;
    [SerializeField]
    private float currentScale;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();

        currentScale = 1;
        isBoucingUp = false;

        Player.OnPowerLevelIncreased += pl => {
            isBoucingUp = true;
        };
    }
    
    // Update is called once per frame
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
