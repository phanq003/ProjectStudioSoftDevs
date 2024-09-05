using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupControl : MonoBehaviour
{
    //ref to manager
    public GameObject selectedGame;
    public GameObject gameDescriptionManager;
    public GameObject gameSelectionMenu;
    public GameObject gameSelectionManager;

    void Awake() 
    {
        gameDescriptionManager = GameObject.FindGameObjectWithTag("GameDescriptionManager");
        gameSelectionMenu = GameObject.FindGameObjectWithTag("GameSelectionMenu");
        gameSelectionManager = GameObject.FindGameObjectWithTag("GameSelectionManager");
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSelectedGame(GameObject selectedGame){
        this.selectedGame = selectedGame;
    } 

    public void showPopup(){ 
        string name = selectedGame.name;

       
        gameSelectionMenu.SetActive(false);
        gameObject.SetActive(true);
        gameSelectionManager.SetActive(false);
        GameDescriptionManager gameDescriptionManagerScript = gameDescriptionManager.GetComponent<GameDescriptionManager>();
        switch(name)
        {
            case "GameTemp 1":
                GameObject game = GameObject.FindGameObjectWithTag("WhackAMole");
                gameDescriptionManagerScript.gameDetails = game;
                gameDescriptionManagerScript.setUpImage();
                //manager.setupImage()
            break;
        }
        //TODO show smth depending on a var in the gameObj
    }

    public void hidePopup(){ //When they exit the popup or smth
        //TODO
    }
}
