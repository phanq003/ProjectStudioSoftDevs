using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private GameUIScript gameUI;
    private int playerScore;
    private int healthNumber;
    private float timeRemaining;

    void Start()
    {
        healthNumber = gameUI.getHealth().Length;
        timeRemaining = MaxTime;
        
    }

    void Update()
    {
        if (timeRemaining > 0 && healthNumber > 0)
        {
            timeRemaining -= Time.deltaTime;
            gameUI.updateTimer(timeRemaining / MaxTime);
        }
        else
        {
            gameOver();
        }
    }

    public int getHealthNumber() 
    {
        return healthNumber;
    }

    public float getTimeRemaining() 
    {
        return timeRemaining;
    }

    public void addScore()
    {
        if (healthNumber > 0 && timeRemaining > 0)
        {
            playerScore++;
            gameUI.updateScore(playerScore);
            rampUp();
        }
       
    }

    public void loseHealth()
    {
        if (healthNumber > 0)
        {
            healthNumber--;
            gameUI.updateHealth(healthNumber);
        }
    }

    {
    }
    {
    }

    {
        {
        }
    }

    {
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

    {
    
}
