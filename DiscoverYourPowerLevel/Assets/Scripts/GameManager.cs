using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public Player Player1;
    public Player Player2;

    private void Awake() {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        Player1 = new Player();
        Player2 = new Player();
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

        Debug.Log($"p1: {Player1.PowerLevel}, p2: {Player2.PowerLevel}");

    }
}
