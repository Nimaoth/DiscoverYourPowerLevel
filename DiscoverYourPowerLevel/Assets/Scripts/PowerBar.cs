using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PowerBar : MonoBehaviour
{
    public bool player1;
    int currentColorIndex = 0;
    public GameObject cylinder;
    Renderer rend;
    public Transform fireTransform;
    Vector3 startPosition;
    private float[] rArray =
    {
        0xAB, 0xB3, 0xBA, 0xC2, 0xCA, 0xD1, 0xD9, 0xE0, 0xE8, 0xF0, 0xF7,
        0xFF,
        0xFF,
        0xFF,
        0xFF,
        0xFF,
        0xFF,
        0xFF,
        0xFF,
        0xFF,
        0xFF,
        0xFF,
        0xFF,
        0xFF,
        0xFF,
        0xFF,
        0xFF,
        0xFF,
        0xFF,
        0xFF,
        0xFF
    };
    private float[] gArray =
    {
        0xFF, 0xF7, 0xF0, 0xE8, 0xE0, 0xD9, 0xD1, 0xCA, 0xC2, 0xBA, 0xB3, 0xAB, 0xA5, 0x9F, 0x9A, 0x94, 0x8E, 0x88, 0x82, 0x7C, 0x77, 0x71, 0x6B, 0x61, 0x58, 0x4E, 0x44, 0x3A, 0x31, 0x27, 0x1D, 0x13, 0x0A, 0x00
    };

    public Color[] farbVerlaufPlayerOne = new Color[28];
    public Color[] farbVerlaufPlayerTwo = new Color[28];

    // Use this for initialization
    void Start()
    {
        rend = cylinder.GetComponent<Renderer>();
        //fireTransform = cylinder.GetComponentInChildren<ParticleSystem>().transform;
        //startPosition = new Vector3(fireTransform.position.x, 0.0271f, fireTransform.position.z);
        //fireTransform.position = startPosition;
        for(int i = 0; i < farbVerlaufPlayerOne.Length; i++)
        {
            farbVerlaufPlayerOne[i] = new Color((rArray[i]-30 / 255), gArray[i] / 255, 0);
            farbVerlaufPlayerTwo[i] = new Color(0, gArray[i] / 255, (rArray[i]-30) / 255);
        }
        currentColorIndex = 0;
        if(player1)
        {
            rend.sharedMaterial.color = farbVerlaufPlayerOne[currentColorIndex];
        }
        else
        {
            rend.sharedMaterial.color = farbVerlaufPlayerTwo[currentColorIndex];                
        }

    }

    // Update is called once per frame
    public void UpdateBar(float p)
    {
        //0,0271 bis 0,0641
        //fireTransform.position = new Vector3(startPosition.x, startPosition.y + p * distance, startPosition.z);
        rend.sharedMaterial.SetFloat("_Flow", p);
        //fireTransform.position = new Vector3(fireTransform.position.x, fireTransform.position.y + p, transform.position.z);
    }

    public void UpdateColor()
    {
        if(currentColorIndex < 27)
        {
            currentColorIndex++;
            if(player1)
            {
                rend.sharedMaterial.color = farbVerlaufPlayerOne[currentColorIndex];
            }
            else
            {
                rend.sharedMaterial.color = farbVerlaufPlayerTwo[currentColorIndex];                
            }
           
        }
    }
}
