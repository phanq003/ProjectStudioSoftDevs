using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CircleObjectScript : MonoBehaviour
{
    private float duration;
    /*private float finalDuration = 2;*/
    private GameManagerScript gameManager;
    public GameObject circleParticles;
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
        if (duration < 2)
        {
            duration += Time.deltaTime;
        }
        else
        {
            destroyCircle();
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
        ParticleSystem particle = circleParticles.GetComponent<ParticleSystem>();

        cursorManager.setCursorMalletHit();
        destroyCircle();
        particle.Play();
        gameManager.addScore();
    }

    public void destroyCircle()
    {
        Destroy(gameObject);
    }

    /*public void setDuration(float number)
    {
        finalDuration -= number;
        animator.speed = 1 * (2 / finalDuration);
    }*/

    /*public float getDuration()
    {
        return finalDuration;
    }*/
}
