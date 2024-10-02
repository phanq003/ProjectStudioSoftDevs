using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FestiveModeScript : MonoBehaviour
{
    public Image imageRenderer;
    public Sprite onMode;
    public Sprite offMode;
    public Boolean festiveMode = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMode(){
        if (festiveMode){ //If it is currently festive
            imageRenderer.sprite = offMode;
            festiveMode = false;
        }
        else {
            imageRenderer.sprite = onMode;
            festiveMode = true;
        }

    }
}
