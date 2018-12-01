using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TitleScreenButton : MonoBehaviour {

    // Use this for initialization
    public Sprite buttonDefault;
    public Sprite buttonPressed;
    public Button button;

    public float powerLevel = 0;
	void Start () {
        button.onClick.AddListener(ChangeImageOnClick);
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Power is over " + powerLevel + "!!!");
        if(powerLevel > 0)
            powerLevel -= 0.001f;
	}

    void ChangeImageOnClick()
    {
        button.image.sprite = buttonPressed;
        if(powerLevel <= 1)
            powerLevel += 0.025f;
    }

    
}
