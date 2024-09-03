using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleObjectScript : MonoBehaviour
{
    private float duration;
    private GameManagerScript gameManager;
    public GameObject circleParticles;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        circleParticles = Instantiate(circleParticles, gameObject.transform.position, transform.rotation);
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

    void OnMouseDown()
    {
        ParticleSystem particle = circleParticles.GetComponent<ParticleSystem>();

        destroyCircle();
        particle.Play();
        gameManager.addScore();
    }

    public void destroyCircle()
    {
        Destroy(gameObject);
    }

    public void setDuration(float number)
    {
        duration -= number;
    }

    public float getDuration()
    {
        return duration;
    }
}
