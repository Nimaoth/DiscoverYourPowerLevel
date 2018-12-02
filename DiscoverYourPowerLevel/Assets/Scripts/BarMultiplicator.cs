using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarMultiplicator : MonoBehaviour {


	public PowerBar player1Bar;
	public PowerBar player2Bar;

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
		string s = "";
		if(level != 0)
		{
			s = "x" + level.ToString();
		}
		player1Multi.text = s;
		isBoucingUp = true;
		player1Bar.UpdateColor();
	}

	public void progressPlayer2(int level)
	{
		string s = "";
		if(level != 0)
		{
			s = level.ToString() + "x";
		}
		player2Multi.text = s;
		isBoucingUp = true;		
		player2Bar.UpdateColor();

	}
}
