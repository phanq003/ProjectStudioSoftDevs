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
    public Button[] interfaceButtons;
    public Text highScoreText;
    public Text[] resultScore;
    public Text resultComment;
    public Image[] health;
    public GameObject pauseButton;
    public GameObject[] pauseGameUI;
    public GameObject[] gameOverUI;
    private bool isPaused;
    private bool isGameOver;
    private float durationButtonDelay = 1;
    private string highScoreBeatenComment = "You beat the High Score! Enter your name for show!";
    private string regularResultComment = "Awesome! Enter your name to save your score!";
    [SerializeField] Image correctImage;
    [SerializeField] Image wrongImage;
    private float durationFeedbackDelay = 1;
    [SerializeField] private Text startText;
    private float durationStartText = 1;


    void Start()
    {
        populatedAnswers = new List<Text>();
        isPaused = false;
        isGameOver = false;

        foreach (Button button in interfaceButtons)
        {
            button.enabled = false;
        }

        updateHighScore();
    }

    void Update()
    {
        
        if (startText.gameObject.activeSelf)
        {
            if (durationStartText > 0)
            {
                durationStartText -= Time.deltaTime;
            }
            else
            {
                startText.gameObject.SetActive(false);
            }
        }
        
        else if (isGameOver)
        {
            if (durationButtonDelay > 0)
            {
                durationButtonDelay -= Time.deltaTime;
            }
            else
            {
                enableInterfaceButtons();
            }
        }
        else if (correctImage.gameObject.activeSelf || wrongImage.gameObject.activeSelf)
        {
            if (durationFeedbackDelay > 0)
            {
                durationFeedbackDelay -= Time.deltaTime;
            }
            else
            {
                correctImage.gameObject.SetActive(false);
                wrongImage.gameObject.SetActive(false);
                durationFeedbackDelay = 1;
            }
        }
    }

    public Image[] getHealth()
    {
        return health;
    }

    public void updateHealth(int healthNumber)
    {
        health[healthNumber].gameObject.SetActive(false);
    }

    public void updateQuestion(string question)
    {
        questionText.text = question;
    }

    public void updateResultScore()
    {
        foreach (Text result in resultScore)
        {
            result.text = scoreText.text;
        }
    }

    public void gameOver()
    {
        pauseButton.SetActive(false);
        isGameOver = true;
        bool commentResult = updateHighScore();
        generateResultComment(commentResult);
        updateResultScore();

        foreach (GameObject ui in gameOverUI)
        {
            ui.SetActive(true);
        }
    }

    public void enableInterfaceButtons()
    {
        foreach (Button button in interfaceButtons)
        {
            button.enabled = true;
        }
    }

    public void disableAnswers()
    {
        foreach (Button button in answerButtons)
        {
            button.enabled = false;
        }
    }

    public void enableAnswers()
    {
        foreach (Button button in answerButtons)
        {
            button.enabled = true;
        }
    }

    public void pauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        updateResultScore();

        foreach (GameObject ui in pauseGameUI)
        {
            ui.SetActive(true);
        }

        disableAnswers();
    }

    public void resumeGame()
    {
        Time.timeScale = 1.0f;
        isPaused = false;

        foreach (GameObject ui in pauseGameUI)
        {
            ui.SetActive(false);
        }

        enableAnswers();
    }

    public bool getGamePaused()
    {
        return isPaused;
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

    public void activeCorrect()
    {
        correctImage.gameObject.SetActive(true);
    }

    public void activeWrong()
    {
        wrongImage.gameObject.SetActive(true);
    }

    public void restartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quitGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("GameSelectScene");
    }

    public bool updateHighScore()
    {
        if (PlayerPrefs.HasKey("RecallHighScore"))
        {
            if (int.Parse(scoreText.text) > PlayerPrefs.GetInt("RecallHighScore"))
            {
                PlayerPrefs.SetInt("RecallHighScore", int.Parse(scoreText.text));
                return true;
            }
        }
        else
        {
            PlayerPrefs.SetInt("RecallHighScore", int.Parse(scoreText.text));
        }
        highScoreText.text = PlayerPrefs.GetInt("RecallHighScore").ToString();

        return false;
    }

    public void generateResultComment(bool result)
    {
        Debug.Log(result);

        if (result)
        {
            resultComment.text = highScoreBeatenComment;
        }
        else
        {
            resultComment.text = regularResultComment;
        }
    }
}
