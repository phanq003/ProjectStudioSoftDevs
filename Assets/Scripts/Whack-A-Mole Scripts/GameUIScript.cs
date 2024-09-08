using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIScript : MonoBehaviour
{
    [SerializeField] private GameManagerScript gameManager;
    public Text highScoreText;
    public Text playerScoreText;
    public Image[] health;
    public GameObject[] gameOverUI;
    public Image radialTimerImage;

    // Start is called before the first frame update
    void Start()
    {

        updateHighScore();
    }

    // Update is called once per frame
    void Update()
    {
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

        foreach (GameObject ui in gameOverUI)
        {
            ui.SetActive(true);
        }
        

    }




    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void returnToGameSelect()
    {
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

}