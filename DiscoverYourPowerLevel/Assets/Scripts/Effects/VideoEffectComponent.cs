using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoEffectComponent : MonoBehaviour {

    VideoPlayer videoplayer;

    // Use this for initialization
    void Start () {
        Debug.Log("playing video");

        float m_XAxis, m_YAxis;

        transform.SetParent(UIManager.Instance.VideoEffectCanvas.transform);
        videoplayer = GetComponent<VideoPlayer>();

         RectTransform m_RectTransformCanvas = UIManager.Instance.VideoEffectCanvas.GetComponent<RectTransform>();


        float panelWidth = m_RectTransformCanvas.rect.width * m_RectTransformCanvas.localScale.x;
        float panelHeight = m_RectTransformCanvas.rect.height * m_RectTransformCanvas.localScale.y;

        RectTransform m_RectTransform = videoplayer.GetComponent<RectTransform>();

        m_XAxis = Random.Range(0, panelWidth - m_RectTransform.rect.width);
        m_YAxis = Random.Range(0, panelHeight - m_RectTransform.rect.height);

        m_RectTransform.anchoredPosition = new Vector2(m_XAxis, m_YAxis);
        


        videoplayer.Play();
        //videoplayer.loopPointReached += (_) => Destroy(gameObject);
    }
}
