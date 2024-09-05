using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PreGameInstructScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void playGame()
    {
        Debug.Log("the button is being pressed");
        SceneManager.LoadScene("Whack-A-Mole");
    }

    public void BackToSelection()
    {
        SceneManager.LoadScene("GameSelectScene");
    }
}

