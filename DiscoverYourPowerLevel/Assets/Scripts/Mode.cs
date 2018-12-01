using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Mode : ScriptableObject {

    protected Player player1;
    protected Player player2;

    public void Start() {
        player1 = GameManager.Instance.Player1;
        player2 = GameManager.Instance.Player2;
    }

    public abstract void OnUpdate(float time);
}
