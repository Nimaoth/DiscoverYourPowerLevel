using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HitCircle : MonoBehaviour {

    public Transform circle;

    [Range(0, 1)]
    public float openness = 1;

    // Use this for initialization
    void Start () {
        
    }

    float map(float x, float f1, float f2, float t1, float t2) {
        return (x - f1) / (f2 - f1) * (t2 - t1) + t1;
    }
    
    // Update is called once per frame
    void Update () {
        float scale = map(openness, 0, 1, 1, 2);
        circle.localScale = new Vector3(scale, scale, scale);
    }
}
