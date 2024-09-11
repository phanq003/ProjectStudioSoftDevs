using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Hole : MonoBehaviour
{
    public LogicScript logic;
    int holeCounter = 1;
    public ScoreSO scoreSO;
    private void Awake()
    { 
        logic = GameObject.Find("LogicManager").GetComponent<LogicScript>();
        scoreSO.HoleCounter++;
        /* this code that would automatically add the scene makes unity not load for some reason therefore they are added in manual for now curren
        foreach(EditorBuildSettingsScene theScene in EditorBuildSettings.scenes)
        {
            if(theScene.enabled)
            {
                scenes.Add(theScene.path);
            }
        }
        for (int i= 0; i < scenes.Count; i++)
        { 
        
            if (!scenes[i].Contains("Hole"))
            {
                scenes.Remove(scenes[i]);
            }
            else
            {
                int indexOf = scenes.IndexOf(scenes[i]);   
                string newScene = "Hole" + (indexOf + 1).ToString();
                scenes.Insert(indexOf, newScene);
            }
        }*/
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("Ball"))
        {
            other.gameObject.SetActive(false);
            logic.manageNextScene();
            holeCounter++;

        }
    }
}
