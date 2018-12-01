using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour {

    public GameObject cylinder;
    public GameObject empty;
    Renderer rend;

	// Use this for initialization
	void Start () {
        rend = cylinder.GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        rend.material.SetFloat("_Flow", empty.GetComponent<TitleScreenButton>().powerLevel);
	}
}
