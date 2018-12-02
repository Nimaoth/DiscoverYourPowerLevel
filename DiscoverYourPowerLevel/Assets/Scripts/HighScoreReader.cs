using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HighScoreReader : MonoBehaviour {

    HighScoreManager highscoreMan;
    public GameObject HighscorePrefab;
    public GameObject firstPlacePrefab;
    public GameObject panelFirstPlace;
    public GameObject panel2to5Place;
    public GameObject panel6to9Place;

    public GameObject inputNameBox1;
    public GameObject inputNameBox2;

    // Use this for initialization
    void Start () {
        highscoreMan = HighScoreManager._instance;

        updateList();

        InputField player1NameInpField = inputNameBox1.GetComponentInChildren<InputField>();
        InputField player2NameInpField = inputNameBox2.GetComponentInChildren<InputField>();

        inputNameBox1.transform.Find("PlayerName").GetComponent<Text>().text += (int)GameManager.Instance.Player1.PowerLevel;
        inputNameBox2.transform.Find("PlayerName").GetComponent<Text>().text += (int)GameManager.Instance.Player2.PowerLevel;
        //player1NameInpField.
        player1NameInpField.onEndEdit.AddListener((a) => {
            inputNameBox1.SetActive(false);
            highscoreMan.SaveHighScore(a, (int)GameManager.Instance.Player1.PowerLevel);
            inputNameBox2.SetActive(true);
        });
        //player2NameInpField.
        player2NameInpField.onEndEdit.AddListener((a) => {
            inputNameBox2.SetActive(false);
            highscoreMan.SaveHighScore(a, (int)GameManager.Instance.Player2.PowerLevel);
            updateList();
        });


       
    }

    // Update is called once per frame
    void Update () {
		
	}
    void updateList()
    {
        foreach (Transform child in panelFirstPlace.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Transform child in panel2to5Place.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Transform child in panel6to9Place.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        List<Scores> scoreList = highscoreMan.GetHighScore();
        if (scoreList.Count > 0)
        {

            GameObject tempObj = Instantiate(firstPlacePrefab);
            tempObj.transform.SetParent(panelFirstPlace.transform, false);
            tempObj.GetComponent<Text>().text = "1. " + scoreList[0].name + " - " + scoreList[0].score;


            for (int i = 1; i < 5 && i < scoreList.Count; i++)
            {
                tempObj = Instantiate(HighscorePrefab);
                tempObj.transform.SetParent(panel2to5Place.transform);
                tempObj.GetComponent<Text>().text = i + 1 + ". " + scoreList[i].name + " - " + scoreList[i].score;
            }

            for (int i = 5; i < 9 && i < scoreList.Count; i++)
            {
                tempObj = Instantiate(HighscorePrefab);
                tempObj.transform.SetParent(panel6to9Place.transform);
                tempObj.GetComponent<Text>().text = i + 1 + ". " + scoreList[i].name + " - " + scoreList[i].score;
            }
        }
    }
}
