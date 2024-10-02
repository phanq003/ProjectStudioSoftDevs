using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.ComponentModel;
using System.Linq;
using System.Diagnostics;
using System;
using UnityEngine.SocialPlatforms.Impl;

public class LogicScript : MonoBehaviour
{
    public static LogicScript Instance;
    public static int numOfHoles = 3;
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
    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
    {
        playerHoleValue = new List<int>(numOfHoles);
        if (scene.name == "Hole1")
        {
            scoreValue.Score = 0;
            scoreValue.PreviousHoleScore = 0;
            scoreValue.HoleCounter = 1;

            this.resetVal();
            scoreValue.PlayerScores = playerHoleValue;
        }
        else
        {
            playerHoleValue = scoreValue.PlayerScores;
            previousHoleScore = scoreValue.PreviousHoleScore;
        }
        updateScore();
        
    }
    public void Awake()
    {
        scenes.Insert(0, "Hole1");
        scenes.Insert(1, "Hole2");
        scenes.Insert(2, "Hole3");
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
        previousHoleScore = scoreValue.PreviousHoleScore;
        updateScore();
    }
    public void manageNextScene()
    {
        //try { 
            loadHole(scoreValue.HoleCounter, scoreValue.HoleCounter); 
        //} catch { loadEnding(scoreValue.HoleCounter); }
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
    public void resetVal()
    {
        for (int holeValue = 0; holeValue < numOfHoles; holeValue++)
        {
            playerHoleValue.Add(0);
            playerHoleValue[holeValue] = 0;
        }
    }
    public int updateScores(int HoleNum)
    {
        int scoreThisRound = scoreValue.Score - previousHoleScore;
        if (playerHoleValue.Count() == 0 && scoreValue.HoleCounter == 1)
        {
            this.resetVal();
            playerHoleValue[0] = previousHoleScore;
        }
        try
        {
            
            playerHoleValue[HoleNum - 1] = scoreThisRound;
        }
        catch
        {
            playerHoleValue.Add(scoreThisRound);
            //playerHoleValue.Insert(HoleNum -1, scoreThisRound); 
        }
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