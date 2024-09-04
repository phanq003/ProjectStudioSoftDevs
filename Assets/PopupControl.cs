using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupControl : MonoBehaviour
{

    public GameObject selectedGame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSelectedGame(GameObject selectedGame){
        this.selectedGame = selectedGame;
    }

    public void showPopup(){ 
        //TODO show smth depending on a var in the gameObj
    }

    public void hidePopup(){ //When they exit the popup or smth
        //TODO
    }
}
