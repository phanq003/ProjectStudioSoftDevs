using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene(""); //insert game scene here
    }
}
