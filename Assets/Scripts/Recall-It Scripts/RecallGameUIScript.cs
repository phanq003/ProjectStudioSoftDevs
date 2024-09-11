using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RecallGameUIScript : MonoBehaviour
{
    [SerializeField] private GameObject[] questionUI;
    [SerializeField] private Text questionText;
    [SerializeField] private Text[] answerTexts;
    [SerializeField] private Text scoreText;
    [SerializeField] private Button[] answerButtons;
    private List<Text> populatedAnswers;


    void Start()
    {
        populatedAnswers = new List<Text>();

    }

    public void updateQuestion(string question)
    {
        questionText.text = question;
    }

    public void displayQuestion()
    {
        foreach (GameObject ui in questionUI)
        {
            ui.SetActive(true);
        }
    }

    public void hideQuestionDisplay()
    {
        foreach (GameObject ui in questionUI)
        {
            ui.SetActive(false);
        }
    }

    public List<int> randomAnswerNumber(int theAnswer)
    {
        List<int> numberAnswers = new List<int>();
        List<int> numberList = new List<int> {-2, -1, 1, 2};
        int randomNumber = 1;

        while (numberList.Count > 0 && numberAnswers.Count < 2)
        {
            int randomIndex = UnityEngine.Random.Range(0, numberList.Count);
            randomNumber = theAnswer + numberList[randomIndex];
            numberList.RemoveAt(randomIndex);

            if (randomNumber > 0)
            {
                numberAnswers.Add(randomNumber);
            }
        }
        numberAnswers.Add(theAnswer);

        return numberAnswers;
    }

    public void updateAnswers(int theAnswer)
    {
        List<int> answers = randomAnswerNumber(theAnswer);

        int answerIndex = 0;

        while (populatedAnswers.Count != answerTexts.Length)
        {
            int randomAnswerSelection = UnityEngine.Random.Range(0, answerTexts.Length);

            if (!populatedAnswers.Contains(answerTexts[randomAnswerSelection]))
            {
                answerTexts[randomAnswerSelection].text = answers[answerIndex].ToString();
                populatedAnswers.Add(answerTexts[randomAnswerSelection]);
                answerIndex++;
            }
        }
    }

    public string[] getPopulatedAnswers()
    {
        string[] answerStrings = new string[3];

        foreach (Text answerText in populatedAnswers)
        {
            answerStrings[Array.IndexOf(answerTexts, answerText)] = answerText.text.ToString();
        }
        populatedAnswers.Clear();
        
        return answerStrings;
    }

    public void updateScoreDisplay(int score)
    {
        scoreText.text = score.ToString();
        
    }
}
