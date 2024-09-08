using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoleObjectScript : MonoBehaviour
{
    private float duration;
    /*private float finalDuration = 2;*/
    private GameManagerScript gameManager;
    private CursorManagerScript cursorManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        circleParticles = Instantiate(circleParticles, gameObject.transform.position, transform.rotation);
        cursorManager = GameObject.FindGameObjectWithTag("CursorManager").GetComponent<CursorManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (duration < 1.2)
        {
            duration += Time.deltaTime;
        }
        else
        {
            destroyMole();
            gameManager.loseHealth();
            duration = 0;
        }
    }

    void OnMouseEnter()
    {
        cursorManager.setCursorMalletIdle();    
    }

    void OnMouseExit()
    {
        cursorManager.setCursorDefault();
    }

    void OnMouseDown()
    {

        cursorManager.setCursorMalletHit();
        destroyCircle();
        particle.Play();
        gameManager.addScore();
    }

    public void destroyMole()
    {
        Destroy(gameObject);
    }
}
