using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Effect/SpriteEffect")]
public class SpriteEffect : Effect
{
    public Sprite[] sprites;
    public GameObject obj;
    public int bounds_x;
    public int bounds_y;
    public override void Spawn(Vector3 location)
    {
        var x = Instantiate(obj, location, Quaternion.identity);
        var spriteRend = x.GetComponent<SpriteRenderer>();
        var spriteMov = x.GetComponent<spriteMovement>();
        spriteMov.bounds_x = bounds_x;
        spriteMov.bounds_y = bounds_y;
        spriteRend.sprite = sprites[Random.Range(0, sprites.Length)];

    }
}
