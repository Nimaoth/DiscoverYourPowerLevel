using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class GameManager : MonoBehaviour {

    public static GameManager Instance;


    public Player _player1;
    public Player _player2;

    public Player Player1 {
        get {
            if (_player1 == null) {
                var allPlayers = Resources.FindObjectsOfTypeAll(typeof(Player)).Select(p => p as Player);
                Debug.Log($"allPlayers: {string.Join(", ", allPlayers.Select(p => p.Id))}");
                _player1 = allPlayers.FirstOrDefault(p => p.Id == 1);
                Debug.Log($"_player1: {_player1}");
            }
            return _player1;
        }
    }
    public Player Player2 {
        get {
            if (_player2 == null) {
                var allPlayers = Resources.FindObjectsOfTypeAll(typeof(Player)).Select(p => p as Player);
                _player2 = allPlayers.FirstOrDefault(p => p.Id == 2);
            }
            return _player2;
        }
    }

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
