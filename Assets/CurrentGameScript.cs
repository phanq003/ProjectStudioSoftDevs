using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentGameScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject game;
    public GameObject gameDescriptionManager;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        gameDescriptionManager = GameObject.FindGameObjectWithTag("GameDescriptionManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        switch(scene.name)
        {
            
            case "GameDescription": //temp would be WhackAMole
                gameDescriptionManager = GameObject.FindGameObjectWithTag("GameDescriptionManager");
                GameDescriptionManager gameDescriptionManagerScript = gameDescriptionManager.GetComponent<GameDescriptionManager>();
                game = GameObject.FindGameObjectWithTag("WhackAMole");
                gameDescriptionManagerScript.gameDetails = game;
                Debug.Log("HereManager");
                gameDescriptionManagerScript.setUpImage();
            break;

        }
    }
    void onDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
