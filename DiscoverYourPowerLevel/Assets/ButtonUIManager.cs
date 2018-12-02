using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUIManager : MonoBehaviour {


	public static ButtonUIManager instance;

	public Sprite[] Buttons;
	public Sprite[] ButtonsPressed;

	public SpriteRenderer sRendererplayer1;
	public SpriteRenderer sRendererplayer2;

	public SpriteRenderer smallerBox1;
	public SpriteRenderer smallerBox2;
	public SpriteRenderer biggerBox1;
	public SpriteRenderer biggerBox2;


	int player1Counter;
	int player2Counter;

	int patternLength;

	int[] player1Pattern;
	int[] player2Pattern;

	float flashSpeed = 0.04f;

	//RED - 0 
	// Black - 1 
	//WHITE - 2 
	//GREEN - 3 
	//YELLOW - 4 
	//BLUE - 5


	// Use this for initialization
	void Start () {
		instance = this;
	}
	

	public void SetupRhythm(int player1Key, int player2Key)
	{
			patternLength = 1;
			player1Pattern = new int[1];
			player1Pattern[0] = player1Key;
			player1Counter = 0;

			player2Pattern = new int[1];
			player2Pattern[0] = player2Key;
			player2Counter = 0;

			SetButtonPlayer1(player1Pattern[player1Counter], false);
			SetButtonPlayer2(player2Pattern[player2Counter], false);
	}

	public void SetupDoubleMash(int player1Key1, int player1Key2, int player2Key1, int player2Key2)
	{
			patternLength = 2;
			player1Pattern = new int[2];
			player1Pattern[0] = player1Key1;
			player1Pattern[1] = player1Key2;
			player1Counter = 0;

			player2Pattern = new int[2];
			player2Pattern[0] = player2Key1;
			player2Pattern[1] = player2Key2;
			player2Counter = 0;

			SetButtonPlayer1(player1Pattern[player1Counter], false);
			SetButtonPlayer2(player2Pattern[player2Counter], false);
	}

	public void SetupTripleMash(int player1Key1, int player1Key2, int player1Key3, int player2Key1, int player2Key2, int player2Key3)
	{
		
			patternLength = 3;
			player1Pattern = new int[3];
			player1Pattern[0] = player1Key1;
			player1Pattern[1] = player1Key2;
			player1Pattern[2] = player1Key3;
			player1Counter = 0;

			player2Pattern = new int[3];
			player2Pattern[0] = player2Key1;
			player2Pattern[1] = player2Key2;
			player2Pattern[2] = player2Key3;
			player2Counter = 0;

			SetButtonPlayer1(player1Pattern[player1Counter], false);
			SetButtonPlayer2(player2Pattern[player2Counter], false);
	}
	public void SetupIdle()
	{
		//TODO
	}



	public void SetButtonPlayer1(int id, bool pressed)
	{ 
		if(!pressed)
		{
			sRendererplayer1.sprite = Buttons[id];
		}
		else
		{
			sRendererplayer1.sprite = ButtonsPressed[id];
		}
		
	}

	public void SetButtonPlayer2(int id, bool pressed)
	{ 
		if(!pressed)
		{
			sRendererplayer2.sprite = Buttons[id];
		}
		else
		{
			sRendererplayer2.sprite = ButtonsPressed[id];
		}
		
	}

	public void ProgressPlayer1()
	{
		player1Counter = (player1Counter + 1) % patternLength;
		SetButtonPlayer1(player1Pattern[player1Counter], false);
		StartCoroutine(Flash1());
	}

	public void ProgressPlayer2()
	{
		player2Counter = (player2Counter + 1) % patternLength;
		SetButtonPlayer2(player2Pattern[player2Counter], false);
		StartCoroutine(Flash2());

	}


	IEnumerator Flash1()
	{
		SetButtonPlayer1(player1Pattern[player1Counter], true);
		smallerBox1.enabled = true;
		yield return new WaitForSeconds(flashSpeed);
		biggerBox1.enabled = true;
		yield return new WaitForSeconds(flashSpeed);
		biggerBox1.enabled = false;
		yield return new WaitForSeconds(flashSpeed);
		smallerBox1.enabled = false;
		SetButtonPlayer1(player1Pattern[player1Counter], false);
		yield return 0;
	}

	IEnumerator Flash2()
	{
		SetButtonPlayer2(player2Pattern[player2Counter], true);
		smallerBox2.enabled = true;
		yield return new WaitForSeconds(flashSpeed);
		biggerBox2.enabled = true;
		yield return new WaitForSeconds(flashSpeed);
		biggerBox2.enabled = false;
		yield return new WaitForSeconds(flashSpeed);
		smallerBox2.enabled = false;
		SetButtonPlayer2(player2Pattern[player2Counter], false);

		yield return 0;
	}
}
