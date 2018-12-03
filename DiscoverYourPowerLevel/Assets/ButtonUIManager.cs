using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUIManager : MonoBehaviour {

    public SpriteRenderer smallerBox1;
    public SpriteRenderer smallerBox2;
    public SpriteRenderer biggerBox1;
    public SpriteRenderer biggerBox2;

    float flashSpeed = 0.04f;

    IEnumerator Flash1()
    {
        smallerBox1.enabled = true;
        yield return new WaitForSeconds(flashSpeed);
        biggerBox1.enabled = true;
        yield return new WaitForSeconds(flashSpeed);
        biggerBox1.enabled = false;
        yield return new WaitForSeconds(flashSpeed);
        smallerBox1.enabled = false;
        yield return 0;
    }

    IEnumerator Flash2()
    {
        smallerBox2.enabled = true;
        yield return new WaitForSeconds(flashSpeed);
        biggerBox2.enabled = true;
        yield return new WaitForSeconds(flashSpeed);
        biggerBox2.enabled = false;
        yield return new WaitForSeconds(flashSpeed);
        smallerBox2.enabled = false;

        yield return 0;
    }
}
