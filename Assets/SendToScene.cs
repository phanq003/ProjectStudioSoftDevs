using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SendToScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nextScene()
    {
        Debug.Log("aA");
        SceneManager.LoadScene("GameDescription");
        Debug.Log("AA");
    }
}
