using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class ShatterRefraction : MonoBehaviour {

    public Material shatterMaterial;
    public bool inTitleScreen;

    public static ShatterRefraction Instance;

    private void Awake()
    {
        Instance = this;
        shatterMaterial.SetFloat("_Strength", 0f);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //shatterMaterial.SetFloat("_Strength", 0f);
        Graphics.Blit(source, destination, shatterMaterial);
    }

    public void ShatterScreen()
    {
        StartCoroutine(Shatter());
    }
    private IEnumerator Shatter()
    {
        if(inTitleScreen)
            GetComponent<AudioSource>().Play();
        for (float i = 0; i < 0.1f; i += Time.deltaTime)
        {
            shatterMaterial.SetFloat("_Strength", i);
            yield return new WaitForEndOfFrame();
        }
        
    }
}
