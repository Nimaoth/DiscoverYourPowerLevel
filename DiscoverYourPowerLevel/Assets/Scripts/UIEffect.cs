using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEffect : MonoBehaviour {

    // Use this for initialization
    void Start () {
        transform.parent = EffectManager.Instance.EffectCanvas;
        
        var pos = transform.position;
        pos.y = Random.Range(0, 500);
        transform.position = pos;
    }
    
    // Update is called once per frame
    void Update () {
        transform.position += new Vector3(100, 0, 0) * Time.deltaTime;

        if (transform.position.x >= 2000)
            Destroy(gameObject);
    }
}
