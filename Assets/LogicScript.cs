using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.ComponentModel;

public class LogicScript : MonoBehaviour
{
    public static LogicScript Instance;
    public int strokeCount;
    public Text strokeText;

    public void awake()
    {
        if(Instance ==  null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [ContextMenu("Add Stroke")]
    public void addStroke()
    {
        strokeCount += 1;
        strokeText.text = strokeCount.ToString();

    }

    public void resetStrokes()
    {
        strokeCount = 0;
    }

    public void loadHole(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

}