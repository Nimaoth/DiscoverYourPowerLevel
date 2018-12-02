using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarMultiplicator : MonoBehaviour {

	public Text player1Multi;
	public Text player2Multi;

	public float maxScale;
    public float bounceSpeed = 1;


	[SerializeField]
    private bool isBoucingUp;
    [SerializeField]
    private float currentScale;



	void Start () {

        currentScale = 1;
        isBoucingUp = false;
    }

	void Update () {
        if (isBoucingUp) {
            currentScale += bounceSpeed * Time.deltaTime;
        } else {
            currentScale -= bounceSpeed * Time.deltaTime;
        }

        if (currentScale < 1) {
            currentScale = 1;
        }
        else if (currentScale >= maxScale) {
            currentScale = maxScale;
            isBoucingUp = false;
        }

        transform.localScale = new Vector3(currentScale, currentScale, currentScale);
    }

	
	public void progressPlayer1(int level)
	{
		player1Multi.text = level.ToString();
		isBoucingUp = true;
	}

	public void progressPlayer2(int level)
	{
		player2Multi.text = level.ToString();
		isBoucingUp = true;		
	}
}
