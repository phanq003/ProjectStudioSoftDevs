using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public string sceneName;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           SceneManager.LoadScene("GameSelectScene");
        }
    }

}
