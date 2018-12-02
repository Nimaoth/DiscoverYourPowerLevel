using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour
{

    private static HighScoreManager m_instance;
    //Anzahl Elemente die in der Highscore Liste gespeichert werden
    private const int LeaderboardLength = 10;
    public float minTimeSpent = 10;
    //Start() ist nur zum testen der klasse da
    /*
    private void Start()
    {
        ClearLeaderBoard();
        SaveHighScore("Minh Stinkt", 35000);
        SaveHighScore("OmegaLul1", 30000);
        SaveHighScore("OmegaLul2", 20000);
        SaveHighScore("OmegaLul3", 10000);
        SaveHighScore("OmegaLul4", 50000);
        SaveHighScore("OmegaLul5", 15000);
        SaveHighScore("OmegaLul6", 3000);
        SaveHighScore("OmegaLul6", 3000);
        SaveHighScore("OmegaLul6", 3000);
        SaveHighScore("OmegaLul6", 3000);
        SaveHighScore("OmegaLul6", 3000);

        var highscores = GetHighScore();
        Debug.Log(string.Join("\n" , highscores.Select((a) => a.name + " score: " + a.score)));
    }
    */
    //erstellen von einem HighScoreManager Objekt, in dem später die Infos gespeichert werden, falls noch nicht vorhanden.
    public static HighScoreManager _instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = new GameObject("HighScoreManager").AddComponent<HighScoreManager>();
            }
            return m_instance;
        }
    }
    
    void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
        }
        else if (m_instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start ()
    {
        minTimeSpent = 10;
    }

    public void SaveHighScore(string name, int score)
    {
        List<Scores> HighScores = GetHighScore();

        HighScores.Add(new Scores { score = score, name = name });
        // sortieren, wobei je zwei werte a und b mit ihrem score verglichen werden.
        HighScores.Sort((a, b) => b.score - a.score);

       for(int i = 0; i < LeaderboardLength && i < HighScores.Count; i++)
        {
            PlayerPrefs.SetString("HighScore" + i + "name", HighScores[i].name);
            PlayerPrefs.SetInt("HighScore" + i + "score", HighScores[i].score);
        }

    }

    public List<Scores> GetHighScore()
    {
       List<Scores> HighScores = new List<Scores>();

       for (int i = 0; i < LeaderboardLength && PlayerPrefs.HasKey("HighScore" + i + "score"); i++)
        {
            Scores temp = new Scores();
            temp.score = PlayerPrefs.GetInt("HighScore" + i + "score");
            temp.name = PlayerPrefs.GetString("HighScore" + i + "name");
            HighScores.Add(temp);
        }

        return HighScores;
    }

    public void ClearLeaderBoard()
    {
        //for(int i=0;i<HighScores.
        List<Scores> HighScores = GetHighScore();

        for (int i = 0; i < HighScores.Count; i++)
        {
            PlayerPrefs.DeleteKey("HighScore" + i + "name");
            PlayerPrefs.DeleteKey("HighScore" + i + "score");
        }
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }

    private void Update()
    {
        if(minTimeSpent > 0)
             minTimeSpent -= Time.deltaTime;

        if((Input.GetKeyDown("1") || Input.GetKeyDown("2")) && minTimeSpent <= 0)
        {
            minTimeSpent = 10;
            SceneManager.LoadScene("TitleScreen");
        }
    }
}

public class Scores
{
    public int score;
    public string name;

}

