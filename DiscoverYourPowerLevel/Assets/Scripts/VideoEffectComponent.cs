using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoEffectComponent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.parent = UIManager.Instance.VideoEffectCanvas.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
