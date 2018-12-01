using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {



    // Use this for initialization
    public void Shake(float intesity, float duration) {
        StopAllCoroutines();
        transform.position = Vector3.zero;
        StartCoroutine(DoShake(intesity, duration));
    }

    private IEnumerator DoShake(float intensity, float duration) {
        
        while (intensity > 0) {
            transform.position = Random.onUnitSphere * intensity;
            intensity -= duration;
            yield return null;
        }
        transform.position = Vector3.zero;
    }
}
