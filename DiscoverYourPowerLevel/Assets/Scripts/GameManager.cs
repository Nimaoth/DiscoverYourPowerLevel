using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager _instance = null;
    public static GameManager Instance {
        get {
            if (_instance == null) {
                _instance = new GameObject("GameManager").AddComponent<GameManager>();
                _instance.Player1 = ScriptableObject.CreateInstance<Player>();
                _instance.Player2 = ScriptableObject.CreateInstance<Player>();
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    public CameraShake CameraShake;

    public Player Player1;
    public Player Player2;

    private void Awake() {
        if (_instance != null) {
            Destroy(gameObject);
        }
    }

    void Start () {
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
