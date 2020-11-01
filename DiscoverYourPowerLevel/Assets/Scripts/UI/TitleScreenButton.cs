using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TitleScreenButton : MonoBehaviour {

    public enum ButtonInput
    {
        RED,
        BLACK,
        WHITE,
        GREEN,
        YELLOW,
        BLUE
    };

    public ButtonInput Player1Key;
    public ButtonInput Player1Key2;
    public ButtonInput Player1Key3;
    public ButtonInput Player2Key;
    public ButtonInput Player2Key2;
    public ButtonInput Player2Key3;

    // Use this for initialization
    public Sprite buttonDefault;
    public Sprite buttonPressed;
    public Button button;
    public GameObject titleText;
    bool nextScene;
    bool canClick;
    int p1key;
    int p1key2;
    int p1key3;
    int p2key;
    int p2key2;
    int p2key3;
    bool flowDOwn;

    public ShatterRefraction shatterRefractionScript;

    public float powerLevel = 0;
	void Start () {
        button.onClick.AddListener(ChangeImageOnClick);
        canClick = true;
        flowDOwn = false;
        nextScene = false;

        p1key = (int)Player1Key;
        p1key2 = (int)Player1Key2;
        p1key3 = (int)Player1Key3;
        p2key = (int)Player2Key;
        p2key2 = (int)Player2Key2;
        p2key3 = (int)Player2Key3;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Power is over " + powerLevel + "!!!");
        if(canClick)
        {
            if (powerLevel > 0)
                powerLevel -= 0.001f;
        }
            

        if (powerLevel >= 1 && canClick)
        {
            shatterRefractionScript.ShatterScreen();
            canClick = false;
        }

        if(canClick)
        {
            if (Input.GetKeyDown(p1key.ToString()) ||
            Input.GetKeyDown(p1key2.ToString()) ||
            Input.GetKeyDown(p1key3.ToString()) ||
            Input.GetKeyDown(p2key.ToString()) ||
            Input.GetKeyDown(p2key2.ToString()) ||
            Input.GetKeyDown(p2key3.ToString()))
            {
                button.image.sprite = buttonPressed;
                if (powerLevel <= 1)
                    powerLevel += 0.025f;
            }
        }

        if(!canClick)
        {
            titleText.SetActive(true);
            StartCoroutine(WaitSeconds());
            if(flowDOwn)
            {
                powerLevel -= 0.005f;
                SpriteRenderer[] colors = titleText.GetComponents<SpriteRenderer>();
                for(int i = 0; i < colors.Length; i++)
                {
                   colors[i].color  = new Color(titleText.GetComponentInChildren<Color>().r, titleText.GetComponentInChildren<Color>().g, titleText.GetComponentInChildren<Color>().b, titleText.GetComponentInChildren<Color>().a - 0.01f);
                }
                if (powerLevel <= 0)
                {
                    nextScene = true;
                }

                if(nextScene)
                {
                    SceneManager.LoadScene("LoadScene");
                }
            }
                
        }

        

    } //muss später getestet werden mit dem Input

    void ChangeImageOnClick()
    {
        if (canClick)
        {
            button.image.sprite = buttonPressed;
            if (powerLevel <= 1)
                powerLevel += 0.025f;
        }
        
    }

    IEnumerator WaitSeconds()
    {
        
        yield return new WaitForSeconds(2f);
        flowDOwn = true;    
    }

    
}
