using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManagerScript : MonoBehaviour
{
    private int playerScore;
    public Text playerScoreText;
    private int rampUpThreshold = 10;
    public Image[] health;
    private int healthNumber;
    public GameObject gameOverUI;
    public CircleManagerScript circleManager;
    public CircleObjectScript circleObject;

    void Start()
    {
        healthNumber = health.Length;    
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
            playerScoreText.text = playerScore.ToString();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public int getHealth()
    {
        return healthNumber;
    }

    public void rampUp()
    {
        if (circleManager.getSpawnRate() > 0.5f)
        {
            if (playerScore == rampUpThreshold)
            {
                circleManager.setSpawnRate(0.5f);
                circleObject.setDuration(0.5f);
                rampUpThreshold += 10;
                Debug.Log(circleManager.getSpawnRate());
            }
        }
    }
}
