using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoEffectComponent : MonoBehaviour {

	VideoPlayer videoplayer;

	// Use this for initialization
	void Start () {
		Debug.Log("playing video");
		transform.SetParent(UIManager.Instance.VideoEffectCanvas.transform);
		videoplayer = GetComponent<VideoPlayer>();
		videoplayer.Play();
		videoplayer.loopPointReached += (_) => Destroy(gameObject);
	}
}
