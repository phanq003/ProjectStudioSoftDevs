using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.ComponentModel;
using System.Linq;
using UnityEditor.Networking.PlayerConnection;
using System.Diagnostics;
using System;

public class LogicScript : MonoBehaviour
{
    public static LogicScript Instance;
    public static int numOfHoles = 2;
    //public int strokeCount;
    public Text strokeText;
    public ScoreSO scoreValue;
    //[NonSerialized]
    public List<int> playerHoleValue;
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
            UnityEngine.Debug.Log(scoreValue.PlayerScores.Capacity.ToString());
            scoreValue.Score = 0;
            scoreValue.PreviousHoleScore = 0;
            scoreValue.HoleCounter = 1;
            playerHoleValue = new List<int>();
            for (int holeValue = 0; holeValue < 2; holeValue++)
            {
                playerHoleValue.Add(0); 
            }
      

        }
        playerHoleValue = scoreValue.PlayerScores;
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
        
    }

    [ContextMenu("Add Stroke")]
    public void addStroke()
    {
        scoreValue.Score += 1;
        updateScore();

    }
    public void updateScore()
    {
        if (SceneManager.GetActiveScene().name != "Results")
        {
            strokeText.text = scoreValue.Score.ToString();
        }
    }

    public void resetStrokes()
    {
        scoreValue.Score = 0;
    }

    public void loadHole(string levelName, int HoleNum)
    {
        int scoreThisRound = updateScores(HoleNum);
        TheUIManager.calculateShots(scoreThisRound);
        TheUIManager.nextMap(levelName);
        //SceneManager.LoadScene(levelName);
    }
    public int updateScores(int HoleNum)
    {
        int scoreThisRound = scoreValue.Score - previousHoleScore;
        playerHoleValue[HoleNum - 1] = scoreThisRound;
        previousHoleScore = scoreValue.Score;
        scoreValue.PreviousHoleScore = previousHoleScore;
        scoreValue.PlayerScores = playerHoleValue;
        return scoreThisRound;
    }
    public void loadEnding(int HoleNum)
    {
        int scoreThisRound = updateScores(HoleNum);
        SceneManager.LoadScene("Results");
        //TheUIManager.displayResults();
    }

}