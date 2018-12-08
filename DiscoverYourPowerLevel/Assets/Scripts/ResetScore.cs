using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScore : MonoBehaviour {

    // Use this for initialization
    void Start () {
        GameManager.Instance.Player1.Reset();
        GameManager.Instance.Player2.Reset();
    }
}
