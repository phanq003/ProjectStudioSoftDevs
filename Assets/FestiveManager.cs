using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FestiveManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static FestiveManager instance { get; private set; } //Singleton so its constant across scenes
    public bool isFestive = false;

    void Awake(){
        if (instance != null && instance != this){ //Singleton Pattern
            Destroy(this); 
        } 
        else{
            instance = this; 
            DontDestroyOnLoad(gameObject); //TODO Check if correct
        } 
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTheme(bool themeSet) {
        isFestive = themeSet;
    }
}
