using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSpawnAtEdge : MonoBehaviour {

    // Use this for initialization
    void Start () {
        RectTransform rect;
        RectTransform parent;

        rect = GetComponent<RectTransform>();
        parent = UIManager.Instance.VideoEffectCanvas.GetComponent<RectTransform>();
        rect.SetParent(parent, false);

        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.zero;
        rect.pivot = Vector2.zero;

        float panelWidth = parent.rect.width * parent.localScale.x;
        float panelHeight = parent.rect.height * parent.localScale.y;



        float xMin = -rect.rect.width;
        float xMax = panelWidth;
        
        float yMin = -rect.rect.height;
        float yMax = panelHeight;



        var horizontal = Random.Range(0, 2) < 0.5;
        var coin_flip = Random.Range(0, 2) < 0.5;
        if (horizontal)
        {
            var x_random = Random.Range(xMin, xMax);
            var y_random = coin_flip ? yMin : yMax;
            rect.anchoredPosition = new Vector2(x_random, y_random);
        }
        else
        {
            var x_random = coin_flip ? xMin : xMax;
            var y_random = Random.Range(yMin, yMax);
            rect.anchoredPosition = new Vector2(x_random, y_random);
        }
    }
}
