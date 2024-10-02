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
        GameObject game;
        switch(name)
        {
            case "Whack A Mole":
                game = GameObject.FindGameObjectWithTag("WhackAMole");
                
                //manager.setupImage()
                break;

            // case "Recall It":
            //     break;
            // case "Mini Golf":
            //     break;
            // case "Bingo":
            //     break;
            default:
                game = null;
                break;
        }
        gameDescriptionManagerScript.gameDetails = game; //Need to just assign all cases to fix error
                gameDescriptionManagerScript.setUpImage();
        //TODO show smth depending on a var in the gameObj
    }

    public void hidePopup(){ //When they exit the popup or smth
        //TODO
    }
}
