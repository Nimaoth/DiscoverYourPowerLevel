using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PowerBar : MonoBehaviour
{


    public GameObject cylinder;
    Renderer rend;
    public Transform fireTransform;
    Vector3 startPosition;
    float distance;

    // Use this for initialization
    void Start()
    {
        rend = cylinder.GetComponent<Renderer>();
        //fireTransform = cylinder.GetComponentInChildren<ParticleSystem>().transform;
        //startPosition = new Vector3(fireTransform.position.x, 0.0271f, fireTransform.position.z);
        //fireTransform.position = startPosition;
        distance = 0.0641f - 0.0271f;
    }

    // Update is called once per frame
    public void UpdateBar(float p)
    {
        //0,0271 bis 0,0641
        //fireTransform.position = new Vector3(startPosition.x, startPosition.y + p * distance, startPosition.z);
        rend.material.SetFloat("_Flow", p);
        //fireTransform.position = new Vector3(fireTransform.position.x, fireTransform.position.y + p, transform.position.z);
    }
}
