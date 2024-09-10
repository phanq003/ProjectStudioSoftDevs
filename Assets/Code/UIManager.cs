using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text[] EndingText; 
    public ScoreSO ScoreManager;
    public GameObject RoundSummary;
    private string nextScene;

    public static UIManager Instance;

    enum Rank
    {
        Albatross = -3,
        Eagle = -2,
        Birdie = -1,
        Par = 0,
        Bogey = 1,
        DoubleBogey = 2,
        TripleBogey = 3  
    }
    // Start is called before the first frame update
    void Start()
    {
        RoundSummary.SetActive(false);

    }
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nextMap(string levelName)
    {
        nextScene = levelName;
        RoundSummary.SetActive(true);
    }
    public void onNextClick()
    {
        RoundSummary.SetActive(false);
        SceneManager.LoadScene(nextScene);
    }
    public void calculateShots(int scoreOnHole)
    {
        
        EndingText[1].text = scoreOnHole.ToString();
        string hole = "( ";
        List<int> theScores = ScoreManager.PlayerScores;
        foreach (int score in theScores)
        {
            hole += score.ToString() + " ";
        }
        hole += ")";
        EndingText[2].text = hole;
        EndingText[0].text = "You did it! You earnt a " + determineScoreRank(scoreOnHole) + " for this hole!";

    }

    private string determineScoreRank(int score)
    {
        int scoreForPar = 2; //temp
        foreach (int rank in Enum.GetValues(typeof(Rank))) {
            if (score - rank == scoreForPar)
            {
                string rankName = Enum.GetName(typeof(Rank), rank);
                return rankName; 
            }

        }

        return "QuadrupleBogey";
    }
}
