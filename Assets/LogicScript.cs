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
using UnityEngine.SocialPlatforms.Impl;

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
    private bool playerTurnExceeded = false;

    List<string> scenes = new List<string>(numOfHoles);
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Hole1")
        {
            playerHoleValue = new List<int>(numOfHoles);
            scoreValue.Score = 0;
            scoreValue.PreviousHoleScore = 0;
            scoreValue.HoleCounter = 1;
            
            for (int holeValue = 0; holeValue < 2; holeValue++)
            {
                playerHoleValue.Add(0);
                playerHoleValue[holeValue] = 0;
            }
        }
        scoreValue.PlayerScores = playerHoleValue;
        updateScore();
        
    }
    public void Awake()
    {
        scenes.Insert(0, "Hole1");
        scenes.Insert(1, "Hole2");
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
        if (checkForTurnCap() == true) {
            playerTurnExceeded = true;
            manageNextScene();
        }
        else
        {
            scoreValue.Score += 1;
            updateScore();
        }

    }
    public void updateOnResults()
    {
        playerHoleValue = scoreValue.PlayerScores;
        updateScore();
    }
    public void manageNextScene()
    {
        try { loadHole(scoreValue.HoleCounter, scoreValue.HoleCounter); }
        catch { loadEnding(scoreValue.HoleCounter); }
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

    public void loadHole(int sceneNumber, int HoleNum)
    {
        if (HoleNum != numOfHoles)
        {
            int scoreThisRound = updateScores(HoleNum);
            TheUIManager.calculateShots(scoreThisRound);
            TheUIManager.nextMap(scenes[sceneNumber]);
        }
        else
        {
            loadEnding(HoleNum);
        }
        
    }
    public int updateScores(int HoleNum)
    {
        int scoreThisRound = scoreValue.Score - previousHoleScore;
        UnityEngine.Debug.Log(HoleNum.ToString());
        UnityEngine.Debug.Log(scoreValue.Score.ToString() + "is the score");
        UnityEngine.Debug.Log(previousHoleScore.ToString() + "previous score");
        try
        {
            playerHoleValue[HoleNum - 1] = scoreThisRound;
        }
        catch
        {
            UnityEngine.Debug.Log(playerHoleValue.Count.ToString());
            playerHoleValue.Insert(HoleNum -1, scoreThisRound); 
        }
        UnityEngine.Debug.Log(HoleNum.ToString());
        previousHoleScore = scoreValue.Score;
        scoreValue.PreviousHoleScore = previousHoleScore;
        scoreValue.PlayerScores = playerHoleValue;
        return scoreThisRound;
    }
    public void loadEnding(int HoleNum)
    {
        this.updateOnResults();
        int scoreThisRound = updateScores(HoleNum);
        SceneManager.LoadScene("Results");
    }
    public bool checkForTurnCap()
    {
        if (scoreValue.Score - scoreValue.PreviousHoleScore > 10)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool getPlayerTurnExceeded()
    {
        return playerTurnExceeded;
    }
}