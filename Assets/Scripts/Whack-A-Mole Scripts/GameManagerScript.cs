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
    private int rampUpThreshold = 5;
    private int RampUpThresholdIntervals = 5;
    private int healthNumber;
    private float timeRemaining;
    private float StartRampThreshold = 0.5f;
    private float StartRampThresholdSpawnRateReduction = 0.5f;
    private float FinalRampThreshold = 1.0f;
    private float FinalRampThresholdSpawnRateReduction = 0.2f;

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
        if (moleManager.getSpawnRate() > StartRampThreshold)
        {
            if (playerScore == rampUpThreshold)
            {
                if (moleManager.getSpawnRate() > FinalRampThreshold)
                {
                    moleManager.setSpawnRate(StartRampThresholdSpawnRateReduction);
                }
                else
                {
                    moleManager.setSpawnRate(FinalRampThresholdSpawnRateReduction);
                }
                rampUpThreshold += RampUpThresholdIntervals;
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
