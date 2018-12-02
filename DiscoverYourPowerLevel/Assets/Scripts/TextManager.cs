using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AppearanceEffect{
	APPEARS_OUT_OF_NOWHERE
}
public class TextManager : MonoBehaviour {

	public static TextManager instance;
	public GameObject EffectCanvas;
	public GameObject TextPrefab;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
/*

	public void SpawnText(string text, float x, float y)
	{
		Debug.Log("test created");
		Text myText = Instantiate(TextPrefab).GetComponent<Text>();
		myText.text = text;
		myText.rectTransform.anchoredPosition = new Vector2(x,y);
		myText.gameObject.transform.SetParent(EffectCanvas.transform, false);
	}
 */
	public void SpawnT(string text, float x, float y, AppearanceEffect appearanceEffect, float appearDuration, float duration, int fontsize)
	{
			StartCoroutine(SpawnText(text, x, y, appearanceEffect, appearDuration, duration, fontsize));
	}
	public IEnumerator SpawnText(string text, float x, float y, AppearanceEffect appearanceEffect, float appearDuration, float duration, int fontsize)
	{
		if(appearanceEffect == AppearanceEffect.APPEARS_OUT_OF_NOWHERE)
		{
			Debug.Log("testo");
			Text myText = Instantiate(TextPrefab).GetComponent<Text>();
			myText.text = text;
            myText.fontSize = fontsize;
			myText.rectTransform.anchoredPosition = new Vector2(x,y);
			myText.rectTransform.localScale = new Vector3(0f,0f,0f);
			myText.gameObject.transform.SetParent(EffectCanvas.transform, false);
			
			float currentTime = 0f;
			while(currentTime < appearDuration)
			{
				currentTime += Time.deltaTime;
				float p = currentTime / appearDuration;
				myText.rectTransform.localScale = new Vector3(p,p,p);
				yield return new WaitForEndOfFrame();
			}
			yield return new WaitForSeconds(duration);

			GameObject.Destroy(myText.gameObject);
			
			yield return null;
		}


	}
}
