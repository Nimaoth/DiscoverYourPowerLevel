using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager Instance;

    public Text Player1PowerLevel;
    public Text Player2PowerLevel;

    public HitCircle HitCircle;

    private void Awake() {
        Instance = this;
    }

    private void Update() {
        Player1PowerLevel.text = ((int)GameManager.Instance.Player1.PowerLevel).ToString();
        Player2PowerLevel.text = ((int)GameManager.Instance.Player2.PowerLevel).ToString();
    }
}
