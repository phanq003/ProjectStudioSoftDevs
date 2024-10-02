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

    public GameObject Results;
    public Text ResultText;


    public AudioClip CheerSound;
    public AudioClip BooSound;
    private string nextScene;

    public static UIManager Instance;

    public AudioSource CheerSource;
    public AudioSource BooSource;

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
        CheerSource = GameObject.FindGameObjectWithTag("Cheer").GetComponent<AudioSource>();
        BooSource = GameObject.FindGameObjectWithTag("Boo").GetComponent<AudioSource>();
 
        Results = GameObject.FindGameObjectWithTag("Results");
        if (Results != null)
        {
            ResultText = GameObject.FindGameObjectWithTag("ResultText").GetComponent<Text>();
            Results.SetActive(false);
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
        if (ScoreManager.PreviousHoleScore <= 10)
        {
            EndingText[0].text = "You did it! You earnt a " + determineScoreRank(scoreOnHole) + " for this hole!";
            CheerSource.Play();
        }
        else
        {
            EndingText[0].text = "Whoops! You took 10 shots this round, try again on the next course!";
            BooSource.Play();
        }

    }
    public void displayResults()
    {
        string newText = "";
        int counter = 0;
        List<int> theScores = ScoreManager.PlayerScores;
        foreach (int score in theScores)
        {
            newText += counter.ToString() + " " + score.ToString() + " | ";
        }
        Results.SetActive(true);

        ResultText.text = newText;


    }

    private string determineScoreRank(int score)
    {
        int scoreForPar = 2; //temp
        foreach (int rank in Enum.GetValues(typeof(Rank))) {
            if (score - rank == scoreForPar)
            {
                string rankName = Enum.GetName(typeof(Rank), rank);
                if (rankName == "DoubleBogey" || rankName == "TripleBogey")
                {
                    if (rankName == "DoubleBogey")
                    {
                        rankName = "Double Bogey";
                    }
                    else
                    {
                        rankName = "Triple Bogey";
                    }
                }
                return rankName; 
            }

        }

        return "Quadruple Bogey";
    }
}
