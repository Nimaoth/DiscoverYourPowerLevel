using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMoveInAndOut : MonoBehaviour {

    public float Speed = 100;

    public float MoveIn;
    public float Stay;
    public float MoveOut;

    private RectTransform rect;

    private void Start() {
        rect = GetComponent<RectTransform>();
        var parent = transform.parent.GetComponent<RectTransform>();

        Vector2 mid = new Vector2(parent.rect.width / 2, parent.rect.height / 2);

        StartCoroutine(Move(mid, rect.anchoredPosition));
    }

    private IEnumerator Move(Vector2 target, Vector2 old) {
        var dist = target - old;
        var dir = dist.normalized;

        // Debug.Log($"{target}, {old}, {dist}, {dir}");

        float time = 0;

        // move in
        while (true) {
            if (time > MoveIn + Stay + MoveOut) {
                break;
            } else if (time > MoveIn + Stay) {
                rect.anchoredPosition -= Speed * dir * Time.deltaTime;
            } else if (time > MoveIn) {
                // do nothing
            } else {
                rect.anchoredPosition += Speed * dir * Time.deltaTime;
            }

            time += Time.deltaTime;

            yield return null;
        }

        Destroy(gameObject);
    }
}
