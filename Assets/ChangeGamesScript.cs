using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGamesScript : MonoBehaviour
{
    public GameObject[] miniGames;
    public int currentGame = 0;

    //TODO Vars for positions of each game? 3 pos i think

    void Start() //Unsure if should do this, keep everything visible in first place instead?
    {
        miniGames[currentGame].SetActive(true);

    }
    public void nextGame(){
        miniGames[currentGame].SetActive(false);
        currentGame = (currentGame + 1) % miniGames.Length; //Modulo allows for it to loop back to 0 once limit reached
        Debug.Log(currentGame);

        miniGames[currentGame].SetActive(true);
    }

    public void prevGame(){
        miniGames[currentGame].SetActive(false);
        currentGame -= 1;
        if (currentGame < 0){
            currentGame = miniGames.Length-1; //TODO Check if this works as intended
        }
        Debug.Log(currentGame);

        miniGames[currentGame].SetActive(true);

    }

    public void selectGame(){

    }

}
