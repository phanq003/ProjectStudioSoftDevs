using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FestiveModeScript : MonoBehaviour
{
    public Toggle themeToggle;

    // Start is called before the first frame update
    void Start()
    {
        themeToggle.onValueChanged.AddListener(changeTheme);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void changeTheme(bool themeSet) {
        FestiveManager.instance.SetTheme(themeSet);
    }
}
