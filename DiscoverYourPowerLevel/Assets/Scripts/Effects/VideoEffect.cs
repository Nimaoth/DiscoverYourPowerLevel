using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Custom/Effect/VideoEffect")]
public class VideoEffect : Effect {

    public GameObject obj;
	public VideoClip clip;
    public int bounds_x;
    public int bounds_y;
    
	public override void Spawn(Vector3 location)
    {
        var x = Instantiate(obj, location, Quaternion.identity);
        var videoRenderer = x.GetComponent<VideoPlayer>();
        var rawImage = x.GetComponent<RawImage>();
        RectTransform m_rect = x.GetComponent<RectTransform>();
;       m_rect.sizeDelta = new Vector2(clip.width, clip.height);
        var renderTexture = new RenderTexture((int)clip.width, (int)clip.height, 0, RenderTextureFormat.ARGB32);
        videoRenderer.renderMode = UnityEngine.Video.VideoRenderMode.RenderTexture;
        videoRenderer.targetTexture = renderTexture;
        videoRenderer.clip = clip;
        rawImage.texture = renderTexture;

    }
}
