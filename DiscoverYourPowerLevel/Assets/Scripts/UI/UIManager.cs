using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
public struct PlayerEffectTrigger {
    public int StartPower;
    public Effect Effect;
}

public class UIManager : MonoBehaviour {


    public PlayerEffectTrigger[] Effects;

    [SerializeField]
    private int CurrentEffectIndex = 0;


    private EffectManager EffectManager;

    public GameObject VideoEffectCanvas;

    public static UIManager Instance;

    public Text Player1PowerLevelText;
    public Text Player2PowerLevelText;

    public HitCircle HitCirclePlayer1;
    public HitCircle HitCirclePlayer2;


    public PowerBar Player1PowerBar;
    public PowerBar Player2PowerBar;


    //To be set in Inspector
    public int[] levelThresholds;

    private int currentUILevelPlayer1 = 0;
    private int currentUILevelPlayer2 = 0;
    private int lowerThresholdPlayer1;
    private int upperThresholdPlayer1 = 1;

    private int lowerThresholdPlayer2;
    private int upperThresholdPlayer2 = 1;

    public float currentLevelProgressPlayer1 = 0.0f;
    public float currentLevelProgressPlayer2 = 0.0f;

    int Player1PowerLevel;
    int Player2PowerLevel;

    private void Awake() {
        Instance = this;
    }

    private void Start()
    {
        EffectManager = GameObject.FindGameObjectWithTag("EffectManager").GetComponent<EffectManager>();


        lowerThresholdPlayer1 = 0;
        upperThresholdPlayer1 = levelThresholds[0];
        lowerThresholdPlayer2 = 0;
        upperThresholdPlayer2 = levelThresholds[0];
    }
    private void Update() {

        Player1PowerLevel = (int)GameManager.Instance.Player1.PowerLevel;
        Player2PowerLevel = (int)GameManager.Instance.Player2.PowerLevel;
        
        //check progress player 1
        if(Player1PowerLevel > upperThresholdPlayer1)
        {
            currentUILevelPlayer1 += 1;
            lowerThresholdPlayer1 = levelThresholds[currentUILevelPlayer1-1];
            upperThresholdPlayer1 = levelThresholds[currentUILevelPlayer1];
        }
        //check progress player 2
        if(Player2PowerLevel > upperThresholdPlayer2)
        {
            currentUILevelPlayer2 += 1;
            lowerThresholdPlayer2 = levelThresholds[currentUILevelPlayer2-1];
            upperThresholdPlayer2 = levelThresholds[currentUILevelPlayer2];
        }

        //Update Progress
        float p1 = Player1PowerLevel - lowerThresholdPlayer1;

        currentLevelProgressPlayer1 = p1/(upperThresholdPlayer1-lowerThresholdPlayer1);

        float p2 = Player2PowerLevel - lowerThresholdPlayer2;
        currentLevelProgressPlayer2 = p2/(upperThresholdPlayer2- lowerThresholdPlayer2);

        //Update text
        Player1PowerLevelText.text = Player1PowerLevel.ToString();
        Player2PowerLevelText.text = Player2PowerLevel.ToString();

        //Update Bars
        Player1PowerBar.UpdateBar(currentLevelProgressPlayer1);
        Player2PowerBar.UpdateBar(currentLevelProgressPlayer2);

        if(CurrentEffectIndex != -1 && CurrentEffectIndex<Effects.Length)
        {
            var effectTrigger = Effects[CurrentEffectIndex];
            if (Player1PowerLevel >= effectTrigger.StartPower || Player1PowerLevel >= effectTrigger.StartPower) {
                PlayEffect(effectTrigger.Effect);
            }
        }

    }

    private void PlayEffect(Effect effect) {  
        Debug.Log("Effect played");
        if (CurrentEffectIndex < Effects.Length) {
            // Call EffectManager
            EffectManager.PlayEffect(effect);
            CurrentEffectIndex += 1;
        }
        if (CurrentEffectIndex == Effects.Length)
        {
            CurrentEffectIndex = -1;
        }
        
    }

}
