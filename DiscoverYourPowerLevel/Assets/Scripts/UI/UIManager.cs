using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text Player1PowerLevel;
    public Text Player2PowerLevel;

    private void Update() {
        Player1PowerLevel.text = ((int)GameManager.Instance.Player1.PowerLevel).ToString();
        Player2PowerLevel.text = ((int)GameManager.Instance.Player2.PowerLevel).ToString();
    }
}
