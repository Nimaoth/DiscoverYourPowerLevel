using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager _instance = null;
    public static GameManager Instance {
        get {
            if (_instance == null) {
                var go = new GameObject("GameManager");
                _instance = go.AddComponent<GameManager>();
                _instance.Player1 = ScriptableObject.CreateInstance<Player>();
                _instance.Player2 = ScriptableObject.CreateInstance<Player>();
                DontDestroyOnLoad(go);
            }

            return _instance;
        }
    }

    public Player Player1;
    public Player Player2;

    private void Awake() {
        if (_instance != this) {
            Destroy(gameObject);
        }
    }

    void Update () {
        if (Player1.PowerLevel < 0) {
            Player1.PowerLevel = 0;
        }

        if (Player2.PowerLevel < 0) {
            Player2.PowerLevel = 0;
        }
    }
}
