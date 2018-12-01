using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour {

    public string name;
    public int lifetime = 5;

    void Start()
    {
        StartCoroutine("decreaseLifetime");

    }
    IEnumerator decreaseLifetime()
    {
        yield return new WaitForSeconds(1F);
        lifetime -= 1;
        StartCoroutine("decreaseLifetime");
    }

	void Update () {
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
