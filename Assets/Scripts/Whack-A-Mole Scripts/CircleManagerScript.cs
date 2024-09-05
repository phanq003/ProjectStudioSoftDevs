using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleManagerScript : MonoBehaviour
{
    public GameObject circle;
    private float spawnRate = 3;
    private float timer = 0;
    private float widthOffset = 7.5f;
    private float heightOffset = 3;
    /*public Transform canvas;*/
    private GameManagerScript gameManager;
    public GameObject circleParticles;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else if (gameManager.getHealth() > 0 && gameManager.getTimeRemaining() > 0)
        {
            spawnCircle();
            timer = 0;
        }
    }

    public void spawnCircle()
    {
        float maxHeight = transform.position.y + heightOffset;
        float minHeight = transform.position.y - heightOffset;
        float minWidth = transform.position.x - widthOffset;
        float maxWidth = transform.position.x + widthOffset;

        float randomHeight = Random.Range(minHeight, maxHeight);
        float randomWidth = Random.Range(minWidth, maxWidth);

        Instantiate(circle, new Vector3(randomWidth, randomHeight, 0), transform.rotation);

    }

    public void setSpawnRate(float number)
    {
        spawnRate -= number;
    }
    
    public float getSpawnRate()
    {
        return spawnRate;
    }

}
