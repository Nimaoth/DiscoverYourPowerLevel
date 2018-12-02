using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour {

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
        Debug.Log("Son Goku color: " + sonGokuImage.color);
        redImage.color = new Color(redImage.color.r, redImage.color.g, redImage.color.b, empty.GetComponent<TitleScreenButton>().powerLevel);
        sonGokuImage.color = new Color(sonGokuImage.color.r, sonGokuImage.color.g, sonGokuImage.color.b, empty.GetComponent<TitleScreenButton>().powerLevel - 0.3f);
    }
}
