using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIScript : MonoBehaviour
{
    [SerializeField] private GameManagerScript gameManager;
    public Button[] interfaceButtons;
    public Text highScoreText;
    public Text playerScoreText;
    public Text resultScore;
    public Text resultScoreGameOver;
    public Text resultComment;
    public Image[] health;
    public GameObject pauseButton;
    public GameObject[] pauseGameUI;
    public GameObject[] gameOverUI;
    public Image radialTimerImage;
    private float durationButtonDelay = 2;
    private string highScoreBeatenComment = "You beat the High Score! Enter your name for show!";
    private string regularResultComment = "Awesome! Enter your name to save your score!";
    public CursorManagerScript cursorManager;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Button button in interfaceButtons)
        {
            button.enabled = false;
        }

        updateHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.getTimeRemaining() <= 0 || gameManager.getHealthNumber() <= 0)
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
    }

    public void updateTimer(float timeRemaining)
    {
        radialTimerImage.fillAmount = timeRemaining;
    }

    public void updateScore(int score)
    {
        playerScoreText.text = score.ToString();
    }

    public Image[] getHealth()
    {
        return health;
    }

    public void updateHealth(int healthNumber)
    {
        health[healthNumber].gameObject.SetActive(false);
    }

    public void gameOver()
    {
        cursorManager.setCursorDefault();
        pauseButton.SetActive(false);
        resultScoreGameOver.text = playerScoreText.text;
        bool commentResult = updateHighScore();
        generateResultComment(commentResult);

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

    public void pauseGame()
    {
        cursorManager.setCursorDefault();
        Time.timeScale = 0f;
        gameManager.setGamePaused(true);
        resultScore.text = playerScoreText.text;

        foreach (GameObject ui in pauseGameUI)
        {
            ui.SetActive(true);
        }
    }

    public void resumeGame()
    {
        Time.timeScale = 1.0f;
        gameManager.setGamePaused(false);

        foreach (GameObject ui in pauseGameUI)
        {
            ui.SetActive(false);
        }
    }

    public void restartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void returnToGameSelect()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("GameSelectScene"); //temp whil we don't have a scene for this yet
    }

    public bool updateHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (gameManager.getPlayerScore() > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", gameManager.getPlayerScore());
                return true;
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", gameManager.getPlayerScore());
        }
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();

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