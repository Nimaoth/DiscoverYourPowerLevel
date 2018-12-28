using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraScaler : MonoBehaviour {

    public new Camera camera;
    private new RectTransform transform;

    void Awake() {
        transform = GetComponent<RectTransform>();
    }

    void Start() {
        if (camera == null) {
            camera = FindObjectOfType<Camera>();
        }
    }

    // Update is called once per frame
    void Update() {
        float height = 2f * camera.orthographicSize;
        float width = height * camera.aspect;

        transform.sizeDelta = new Vector2(width, height);
    }
}
