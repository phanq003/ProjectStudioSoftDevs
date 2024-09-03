using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
    private float duration;
    private GameManagerScript gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
    }

    void OnMouseDown()
    {
        destroyCircle();
        gameManager.addScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (duration < 2)
        {
            duration += Time.deltaTime;
        }
        else
        {
            destroyCircle();
            gameManager.loseHealth();
        }
    }

    public void destroyCircle()
    {
        Destroy(gameObject);
    }

    
}
