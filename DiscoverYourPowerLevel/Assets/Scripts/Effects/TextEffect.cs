using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Effect/TextEffect")]
public class TextEffect : Effect {

	[Range(-544.5f , 544.5f)]
	public float x;
	
	[Range(-293f , 293f)]
	public float y;

	public string text;
	public int fontSize;

	public AppearanceEffect appearanceEffect;

	public float appearDuration;

	public float duration;
    public override void Spawn(Vector3 location)
    {
		TextManager.instance.SpawnT(text, x, y, appearanceEffect, appearDuration, duration, fontSize);
    }



}
