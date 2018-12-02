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

    // Use this for initialization
    void Start () {
        highscoreMan = HighScoreManager._instance;
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

    // Update is called once per frame
    void Update () {
		
	}
}
