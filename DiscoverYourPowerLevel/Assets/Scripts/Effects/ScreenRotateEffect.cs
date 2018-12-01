using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenRotateEffect : MonoBehaviour {

    public GameObject cameraAnchorToRotate;
    public int rotationCount;
    public float rotationDuration;
    private float rotTimer;
    private float steps;
    private bool rotate;

    // Use this for initialization
    private void Start()
    {
        steps = 36 / rotationDuration;
    }

    // Update is called once per frame
    void Update () {
        if(rotTimer <= 0)
        {
            rotTimer = rotationDuration;
            rotate = false;
        }

        if(rotate)
        {
            rotTimer -= Time.deltaTime;
            //cameraAnchorToRotate.transform.eulerAngles.z = transform.eulerAngles.z + steps * 10;
        }
        
	}
}
