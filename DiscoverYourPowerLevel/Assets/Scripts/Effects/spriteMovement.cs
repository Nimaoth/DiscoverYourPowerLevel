using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteMovement : MonoBehaviour
{
    public float MinSpeed = 10;
    public float MaxSpeed = 100;

    private Vector2 velocity;
    private RectTransform rect;
    private RectTransform parent;

    // Use this for initialization
    void Start()
    {
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

        var target = new Vector2(Random.Range(panelWidth / 4, 3 * panelWidth / 4), Random.Range(panelHeight / 4, 3 * panelHeight / 4));
        var direction_vec = target - rect.anchoredPosition;
        velocity = direction_vec.normalized * Random.Range(MinSpeed, MaxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        rect.anchoredPosition += velocity * Time.deltaTime;
        if (rect.anchoredPosition.x < - rect.rect.width - 100 || rect.anchoredPosition.x > parent.rect.width + 100
            || rect.anchoredPosition.y < - rect.rect.height - 100 || rect.anchoredPosition.y > parent.rect.height + 100)
        {
            Destroy(gameObject);
        }
    }
}
