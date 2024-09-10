using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.ComponentModel;

public class LogicScript : MonoBehaviour
{
    public static LogicScript Instance;
    //public int strokeCount;
    public Text strokeText;
    public ScoreSO scoreValue;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Hole1")
        {
            scoreValue.Score = 0;
        }
        updateScore();
        
    }
    public void Awake()
    {
        if (Instance ==  null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        updateScore();
    }
    public void Start()
    {
        updateScore();
    }

    [ContextMenu("Add Stroke")]
    public void addStroke()
    {
        scoreValue.Score += 1;
        updateScore();

    }
    public void updateScore()
    {
        strokeText.text = scoreValue.Score.ToString();
    }

    public void resetStrokes()
    {
        scoreValue.Score = 0;
    }

    public void loadHole(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

}