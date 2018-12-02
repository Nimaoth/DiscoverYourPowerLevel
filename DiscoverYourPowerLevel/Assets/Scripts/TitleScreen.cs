using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour {

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

    public GameObject cylinder;
    public GameObject empty;
    Renderer rend;
    public Image redImage;
    public Image sonGokuImage;

	// Use this for initialization
	void Start () {
        rend = cylinder.GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {


        rend.material.SetFloat("_Flow", empty.GetComponent<TitleScreenButton>().powerLevel);
        redImage.color = new Color(redImage.color.r, redImage.color.g, redImage.color.b, empty.GetComponent<TitleScreenButton>().powerLevel);
        sonGokuImage.color = new Color(sonGokuImage.color.r, sonGokuImage.color.g, sonGokuImage.color.b, empty.GetComponent<TitleScreenButton>().powerLevel - 0.3f);
    }
}
