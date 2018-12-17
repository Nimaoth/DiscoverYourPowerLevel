using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

[Serializable]
public struct PlayerEffectTrigger {
    public int StartPower;
    public Effect Effect;
}

public class UIManager : MonoBehaviour {


    public PlayerEffectTrigger[] Effects;

    [SerializeField]
    private int CurrentEffectIndex = 0;

    public GameObject VideoEffectCanvas;

    public Transform ModeUICanvas;

    public GameObject VideoCanvas;

    public static UIManager Instance;

    public TMP_Text Player1PowerLevelText;
    public TMP_Text Player2PowerLevelText;


    public PowerBar Player1PowerBar;
    public PowerBar Player2PowerBar;

    public Material m_Material1;


    //To be set in Inspector
    public int[] levelThresholds;

    private int lowerThresholdPlayer1;
    private int upperThresholdPlayer1 = 1;

    private int lowerThresholdPlayer2;
    private int upperThresholdPlayer2 = 1;

    public float currentLevelProgressPlayer1 = 0.0f;
    public float currentLevelProgressPlayer2 = 0.0f;

    public Player player1;
    public Player player2;

    public PlayerEvent OnMultiplierIncreased;

    private GameObject currentModeUI;

    private void Awake() {
        Instance = this;
    }

    private void Start()
    {
        lowerThresholdPlayer1 = 0;
        upperThresholdPlayer1 = levelThresholds[0];
        lowerThresholdPlayer2 = 0;
        upperThresholdPlayer2 = levelThresholds[0];
        foreach (var c in ModeUICanvas.GetChildren()) GameObject.Destroy(c.gameObject);
    }

    private void Update() {

        int Player1PowerLevel = (int)GameManager.Instance.Player1.PowerLevel;
        int Player2PowerLevel = (int)GameManager.Instance.Player2.PowerLevel;
        
        //check progress player 1
        if(Player1PowerLevel > upperThresholdPlayer1)
        {
            player1.Multiplier += 1;
            if (player1.Multiplier >= levelThresholds.Length) {
                lowerThresholdPlayer1 = upperThresholdPlayer1;
                upperThresholdPlayer1 += 5000;
            } else {
                lowerThresholdPlayer1 = levelThresholds[player1.Multiplier-1];
                upperThresholdPlayer1 = levelThresholds[player1.Multiplier];
            }
            OnMultiplierIncreased.Dispatch(player1);
        }
        //check progress player 2
        if(Player2PowerLevel > upperThresholdPlayer2)
        {
            player2.Multiplier += 1;
            if (player2.Multiplier >= levelThresholds.Length) {
                lowerThresholdPlayer2 = upperThresholdPlayer2;
                upperThresholdPlayer2 += 5000;
            } else {
                lowerThresholdPlayer2 = levelThresholds[player2.Multiplier-1];
                upperThresholdPlayer2 = levelThresholds[player2.Multiplier];
            }
            OnMultiplierIncreased.Dispatch(player2);
        }

        //Update Progress
        float p1 = Player1PowerLevel - lowerThresholdPlayer1;
        currentLevelProgressPlayer1 = p1/(upperThresholdPlayer1-lowerThresholdPlayer1);

        float p2 = Player2PowerLevel - lowerThresholdPlayer2;

        currentLevelProgressPlayer2 = p2/(upperThresholdPlayer2- lowerThresholdPlayer2);

        //Update text
        Player1PowerLevelText.text = Player1PowerLevel.ToString();
        Player2PowerLevelText.text = Player2PowerLevel.ToString();

        Player1PowerLevelText.fontSize = (int)Mathf.Lerp(60, 150, (float)GameManager.Instance.Player1.PowerLevel / 125000);
        Player2PowerLevelText.fontSize = (int)Mathf.Lerp(60, 150, (float)GameManager.Instance.Player2.PowerLevel / 125000);

        //Update Bars
        Player1PowerBar.UpdateBar(currentLevelProgressPlayer1);
        Player2PowerBar.UpdateBar(currentLevelProgressPlayer2);

        if(CurrentEffectIndex != -1 && CurrentEffectIndex<Effects.Length)
        {
            var effectTrigger = Effects[CurrentEffectIndex];
            if (Player1PowerLevel >= effectTrigger.StartPower || Player2PowerLevel >= effectTrigger.StartPower) {
                PlayEffect(effectTrigger.Effect);
            }
        }

        if(upperThresholdPlayer1 > 30000)
        {
            m_Material1.SetFloat("_GlowThickness", 1.3f);
        }
    }


    private void PlayEffect(Effect effect) {  
        //Debug.Log("Effect played");
        if (CurrentEffectIndex < Effects.Length) {
            // Call EffectManager
            EffectManager.Instance.PlayEffect(effect);
            CurrentEffectIndex += 1;
        }
        if (CurrentEffectIndex == Effects.Length)
        {
            CurrentEffectIndex = -1;
        }
        
    }

    public GameObject SetModeUI(GameObject prefab) {
        if (currentModeUI != null) {
            GameObject.Destroy(currentModeUI);
            currentModeUI = null;
        }

        if (prefab != null) {
            currentModeUI = GameObject.Instantiate(prefab, ModeUICanvas);
        }

        return currentModeUI;
    }
}
