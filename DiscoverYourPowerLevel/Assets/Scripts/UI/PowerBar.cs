using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PowerBar : MonoBehaviour
{
    public Player player;
    public new Renderer renderer;

    public Gradient color;

    public float maxLevel;

    // Use this for initialization
    void Start()
    {
        if (renderer == null) renderer = GetComponentInChildren<Renderer>();
        renderer.sharedMaterial.color = color.Evaluate(0);

        player.OnMultiplierIncreased.AddListener(level => {
            renderer.sharedMaterial.color = color.Evaluate(Mathf.Clamp01(level / maxLevel));
        });
    }

    public void UpdateBar(float p)
    {
        renderer.sharedMaterial.SetFloat("_Flow", p);
    }
}
