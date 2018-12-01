using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBar : MonoBehaviour {


    public GameObject cylinder;
    Renderer rend;

	// Use this for initialization
	void Start () {
        rend = cylinder.GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	public void UpdateBar (float p) {
        rend.material.SetFloat("_Flow", p);
	}
}
