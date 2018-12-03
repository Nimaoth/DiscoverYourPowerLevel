using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class HitCircle : MonoBehaviour {

    public Transform circle;

    public float MinScale = 1;
    public float MaxScale = 1.5f;

    [Range(0, 1)]
    public float openness = 1;

    private Image circleImage = null;

    // Use this for initialization
    void Start () {
        if (circle == null) {
            circle = transform.Find("Circle");
        }

        circleImage = circle.GetComponent<Image>();
    }

    float map(float x, float f1, float f2, float t1, float t2) {
        return (x - f1) / (f2 - f1) * (t2 - t1) + t1;
    }
    
    // Update is called once per frame
    void Update () {
        float scale = map(openness, 0, 1, MinScale, MaxScale);
        circle.localScale = new Vector3(scale, scale, scale);

        var c = circleImage.color;
        c.a = 1 - openness;
        circleImage.color = c;
    }
}
