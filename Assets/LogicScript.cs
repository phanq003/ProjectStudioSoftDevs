using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.ComponentModel;
using System.Linq;

public class LogicScript : MonoBehaviour
{
    public static LogicScript Instance;
    public static int numOfHoles = 2;
    //public int strokeCount;
    public Text strokeText;
    public ScoreSO scoreValue;
    public List<int> playerHoleValue = new List<int>(numOfHoles);
    public UIManager TheUIManager;
    public int previousHoleScore;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Hole1")
        {
            scoreValue.Score = 0;
            scoreValue.PreviousHoleScore = 0;
        }
        updateScore();
        
    }
    public void Awake()
    {
        playerHoleValue.Add(scoreValue.Score);
        if (Instance ==  null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        updateScore();
    }
    public void Start()
    {
        updateScore();
        Debug.Log(TheUIManager);
    }

    [ContextMenu("Add Stroke")]
    public void addStroke()
    {
        scoreValue.Score += 1;
        updateScore();

    }
    public void updateScore()
    {
        strokeText.text = scoreValue.Score.ToString();
    }

    public void resetStrokes()
    {
        scoreValue.Score = 0;
    }

    public void loadHole(string levelName, int HoleNum)
    {
        int scoreThisRound = scoreValue.Score - previousHoleScore;
        playerHoleValue[HoleNum - 1] = scoreValue.Score;
        Debug.Log(TheUIManager);
        TheUIManager.calculateShots(scoreThisRound);
        previousHoleScore = scoreValue.Score;
        scoreValue.PreviousHoleScore = previousHoleScore;
        scoreValue.PlayerScores = playerHoleValue;
        TheUIManager.nextMap(levelName);
        //SceneManager.LoadScene(levelName);
    }
    public void loadEnding()
    {
        TheUIManager.displayResults();
    }

}