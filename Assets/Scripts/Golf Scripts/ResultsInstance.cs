using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ResultsInstance : MonoBehaviour
{
    public static ResultsInstance Instance;
    public ScoreSO ScoreManager;
    public GameObject Results;
    public Text ResultText;
    // Start is called before the first frame update
    public void Awake()
    {
        calculateandDisplayResults();
    }
    public void calculateandDisplayResults()
    {
            string newText = "| ";
            int counter = 0;
            List<int> theScores = ScoreManager.PlayerScores;
            foreach (int score in theScores)
            {
                newText += counter.ToString() + " " + score.ToString() + " | ";
            }
            Results.SetActive(true);

            ResultText.text = newText;


    }

    public void exitResults()
    {
        Results.SetActive(false);
        SceneManager.LoadScene("");
        //go back to game select
    }
}
