using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManagerScript : MonoBehaviour
{
    private int playerScore;
    public Text highScoreText;
    public Text playerScoreText;
    public Text playerRecapText;
    private int rampUpThreshold = 10;
    public Image[] health;
    private int healthNumber;
    public GameObject[] gameOverUI;
    public CircleManagerScript circleManager;
    public CircleObjectScript circleObject;
    private Vector3 currentScorePosition;

    void Start()
    {
        currentScorePosition = transform.position;
        healthNumber = health.Length;
        this.changeHighScore();
        
    }

    void Update()
    {
        if (healthNumber == 0)
        {
            gameOver();
        }
    }

    public void addScore()
    {
        if (healthNumber > 0)
        {
            playerScore++;
            playerScoreText.text = "Score: " +  playerScore.ToString();
            rampUp();
        }
       
    }

    public void loseHealth()
    {
        if (healthNumber > 0)
        {
            healthNumber--;
            health[healthNumber].color = Color.black;
        }
    }

    public void restartGame()
    {
        playerScoreText.transform.position = currentScorePosition;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void returnToGameSelect()
    {
        SceneManager.LoadScene("Main Menu"); //temp whil we don't have a scene for this yet
    }

    public void gameOver()
    {
        playerRecapText.text = "Your Score was: " + playerScore.ToString() + "! \n Would you like to try again?";
        playerRecapText.rectTransform.anchoredPosition = new Vector3(400, 300, -10);
        playerRecapText.rectTransform.sizeDelta = new Vector2(140, 80);
        foreach(GameObject ui in gameOverUI)
        {
            ui.SetActive(true);
        }
        this.changeHighScore();
    }

    public int getHealth()
    {
        return healthNumber;
    }

    public void rampUp()
    {
        if (circleManager.getSpawnRate() > 0.1f)
        {
            if (playerScore == rampUpThreshold)
            {
                if (circleManager.getSpawnRate() > 0.5f)
                {
                    circleManager.setSpawnRate(0.5f);
                }
                else if (circleManager.getSpawnRate() > 0.1f)
                {
                    circleManager.setSpawnRate(0.1f);
                }
                rampUpThreshold += 10;
                Debug.Log(circleManager.getSpawnRate());
            }
        }
    }

    public int getPlayerScore()
    {
        return playerScore;
    }

    public int getRampUpThreshold()
    {
        return rampUpThreshold;
    }
    public void changeHighScore()
    {
        //highScoreText.transform.position = new Vector3(-89,-27);  //would change it dynamically here
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (playerScore > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", playerScore);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
        }
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        


        
    }

    
}
