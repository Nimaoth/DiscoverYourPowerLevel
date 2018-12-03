using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class ScreenFlash : MonoBehaviour {

    public Material flashMaterial;
    public float bps;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        flashMaterial.SetFloat("_Strength", Mathf.Abs(-Mathf.Sin(bps * Time.time * Mathf.PI)));
        Graphics.Blit(source, destination, flashMaterial);
    }
}
