using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Custom/Effect/SpriteEffect")]
public class SpriteEffect : Effect
{
    public Sprite[] sprites;
    public GameObject obj;
    public float MinSpeed;
    public float MaxSpeed;

    public override void Spawn(Vector3 location)
    {
        var x = Instantiate(obj, location, Quaternion.identity);
        

        var image = x.GetComponent<Image>();

        if (sprites != null && sprites.Length > 0) {
            image.sprite = sprites[Random.Range(0, sprites.Length)];
        }
    }
}
