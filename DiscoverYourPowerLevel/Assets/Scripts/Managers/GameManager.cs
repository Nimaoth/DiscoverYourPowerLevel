using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public Player Player1;
    public Player Player2;

    // events
    public Event<int> OnLevelIncreased = new Event<int>();
    //

    private void Awake() {
        Instance = this;
    }

    void Update () {
        if (Player1.PowerLevel < 0) {
            Player1.PowerLevel = 0;
        }

        if (Player2.PowerLevel < 0) {
            Player2.PowerLevel = 0;
        }
    }

    public Coroutine StartCoroutineEnum(IEnumerator func) {
        return StartCoroutine(func);
    }
}
