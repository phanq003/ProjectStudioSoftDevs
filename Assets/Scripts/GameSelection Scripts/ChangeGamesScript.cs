using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class ChangeGamesScript : MonoBehaviour
{
    public GameObject[] miniGames;
    public int currentGame = 0;
    public GameObject selectedGame; //Stores game to pass to popup
    public GameObject popup;
    public PopupControl popupControl;
    public Vector3 gamePosLeft = new Vector3(-3.6f, 0, 0);
    public Vector3 gamePosCentre = new Vector3(0, 0, 0);
    public Vector3 gamePosRight = new Vector3(3.6f, 0, 0);

    void Awake() 
    {
        Debug.Log("STARTS");
        popup = GameObject.FindGameObjectWithTag("PopupController");
        popupControl = popup.GetComponent<PopupControl>();
        Debug.Log("START" + popupControl.name);
        
        displayGames();
    }
    void Start()
    {
        popup.SetActive(false);
    }
    public void nextGame(){
        currentGame = (currentGame + 1) % miniGames.Length; //Modulo allows for it to loop back to 0 once limit reached
        Debug.Log("Current Game Index: " + currentGame);

        displayGames();
    }

    public void prevGame(){
        currentGame -= 1;
        if (currentGame < 0){
            currentGame = miniGames.Length-1; //TODO Check if this works as intended
        }
        Debug.Log("Current Game Index: " + currentGame);

        displayGames();

    }

    public void onSelectGame(){
        selectedGame = miniGames[currentGame];
        showPopup(); //TODO CHANGEEEEEEEEEEE!!
    }

    private void showPopup(){ 
        Debug.Log(popupControl.name);
        popupControl.setSelectedGame(selectedGame);
        popupControl.showPopup();
    }

    private void displayGames(){
        //Hiding and unhiding neccasary games
        for (int i = 0; i < miniGames.Length; i++){
            if (i == currentGame || i == (currentGame + 1) % miniGames.Length || i == currentGame-1){ // Checks for the 3 games being displayed
              miniGames[i].SetActive(true);
            }
            else if (currentGame-1 < 0 && i == miniGames.Length-1){ //Checks for edge case where "left" game would be the last game in list
                miniGames[i].SetActive(true);
            }
            else {
                miniGames[i].SetActive(false);
            }
        }

        //Setting positions
    //TODO Check if this should be in the for loop
        miniGames[currentGame].transform.position = gamePosCentre;
        miniGames[(currentGame + 1) % miniGames.Length].transform.position = gamePosRight;
        if (currentGame-1 < 0){
            miniGames[miniGames.Length-1].transform.position = gamePosLeft;
        }
        else {
            miniGames[currentGame-1].transform.position = gamePosLeft;

        }
    }

}
