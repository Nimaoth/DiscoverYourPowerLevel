using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenRotateEffect : MonoBehaviour {

    public GameObject cameraAnchorToRotate;
    public float rotationDuration;
    private float rotTimer;
    private bool rotate = true;

    // Use this for initialization
    private void Start()
    {
        rotTimer = rotationDuration;
    }

    // Update is called once per frame
    void FixedUpdate () {
        
        if (rotTimer <= 0)
        {
            rotTimer = rotationDuration;
            rotate = false;
        }

        if(rotate)
        {
            Debug.Log("Rotation timer: " + rotTimer);
            Debug.Log("Rotation: " + cameraAnchorToRotate.transform.rotation.z);
            rotTimer -= Time.deltaTime;
            cameraAnchorToRotate.transform.Rotate(Vector3.forward, 360 / (50 * rotationDuration) * 0.864f * Time.deltaTime);
            //cameraAnchorToRotate.transform.rotation = new Quaternion(cameraAnchorToRotate.transform.rotation.x, cameraAnchorToRotate.transform.rotation.y, cameraAnchorToRotate.transform.rotation.z + (- 360 / (50 * rotationDuration)), 1);
        }
        
	}
}
