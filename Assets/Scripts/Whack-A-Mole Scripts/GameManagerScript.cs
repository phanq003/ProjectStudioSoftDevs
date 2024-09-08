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
    public MoleManagerScript moleManager;
    [SerializeField] private float MaxTime = 60f;
    private float timeRemaining;
    [SerializeField] private GameObject[] moleHoles;
    private List<GameObject> activeHoles = new List<GameObject>();
    [SerializeField] private int StartingHoles = 3;
    private int SetAllHolesActiveByPlayerScore = 20;
    private float StartRampThreshold = 0.5f;
    private float StartRampThresholdSpawnRateReduction = 0.5f;
    private float FinalRampThreshold = 1.0f;
    private float FinalRampThresholdSpawnRateReduction = 0.2f;
    private bool isPaused;
    private bool gameOverOnce;

    void Start()
    {
        isPaused = false;
        gameOverOnce = true;
        healthNumber = gameUI.getHealth().Length;
        timeRemaining = MaxTime;
        
        setStartActiveHoles();

        foreach (GameObject hole in activeHoles)
        {
            HoleScript holeScript = hole.GetComponent<HoleScript>();
            hole.SetActive(true);
            holeScript.playEntryAnimation();
        }
    }

    void Update()
    {
        if (timeRemaining > 0 && healthNumber > 0)
        {
            timeRemaining -= Time.deltaTime;
            gameUI.updateTimer(timeRemaining / MaxTime);
        }
        else if (gameOverOnce)
        {
            gameUI.gameOver();
            gameOverOnce = false;
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

    public void setStartActiveHoles()
    {
        while (activeHoles.Count < StartingHoles)
        {
            int randomHole = Random.Range(0, moleHoles.Length);

            if (!activeHoles.Contains(moleHoles[randomHole]))
            {
                activeHoles.Add(moleHoles[randomHole]);
            }
        }   
    }

    public void setAllHolesActive()
    {
        foreach (GameObject hole in moleHoles)
        {
            if (!activeHoles.Contains(hole))
            {
                activeHoles.Add(hole);
                HoleScript holeScript = hole.GetComponent<HoleScript>();
                hole.gameObject.SetActive(true);
                holeScript.playEntryAnimation();
            }
        }
        moleManager.allHolesActiveDelay();
    }

    public HoleScript selectHole()
    {
        List<GameObject> activeHoles = getActiveHoles();
        int randomHole = Random.Range(0, activeHoles.Count);
        HoleScript holeScript = activeHoles[randomHole].GetComponent<HoleScript>();

        while (holeScript.isCurrentlyOccupied())
        {
            randomHole = Random.Range(0, activeHoles.Count);
            holeScript = activeHoles[randomHole].GetComponent<HoleScript>();
        }
        holeScript.setOccupied();

        return holeScript;
    }

    public List<GameObject> getActiveHoles()
    {
        return activeHoles; 
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

        if (playerScore == SetAllHolesActiveByPlayerScore) 
        {
            setAllHolesActive();
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

    public bool gamePaused()
    {
        return isPaused;
    }    
    
    public void setGamePaused(bool paused)
    {
        isPaused = paused;
    }
}
