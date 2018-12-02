using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScore : MonoBehaviour {

    // Use this for initialization
    void Start () {
        GameManager.Instance.Player1.PowerLevel = 0;
        GameManager.Instance.Player2.PowerLevel = 0;
    }
}
