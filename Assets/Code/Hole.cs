using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Hole : MonoBehaviour
{
    public LogicScript logic;

    int holeCounter = 1;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Ball"))
        {
            other.gameObject.SetActive(false);
            logic.loadHole("hole2");
            holeCounter++;

        }


    
    }
}
