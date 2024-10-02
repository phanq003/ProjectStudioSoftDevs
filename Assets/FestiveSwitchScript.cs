using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FestiveModeScript : MonoBehaviour
{
    public Toggle themeToggle;

    //COPY FOR FESTIVE 1, then drag and drop corresponding 
    public Image[] imageRenderers;  //Note some may be image, some may be render for each game
    public Sprite[] normalSprites;
    public Sprite[] festiveSprites;
    //

    // Start is called before the first frame update
    void Start()
    {
        //COPY FOR FESTIVE 2
        setTheme();
        //
        themeToggle.onValueChanged.AddListener(changeTheme);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void changeTheme(bool themeSet) {
        FestiveManager.instance.SetTheme(themeSet);
        setTheme(); 
    }

    //COPY FOR FESTIVE 3
    private void setTheme(){
        if (FestiveManager.instance.isFestive){
            for (int i = 0; i < imageRenderers.Length; i++){
                imageRenderers[i].sprite = festiveSprites[i];
            }
        }
        else{
            for (int i = 0; i < imageRenderers.Length; i++){
                imageRenderers[i].sprite = normalSprites[i];
            }
        }
    }
    //
}
