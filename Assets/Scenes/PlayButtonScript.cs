using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{
    public string nextScene;
    public void play()
    {
        SceneManager.LoadScene(nextScene); //insert game scene here
    }
}
