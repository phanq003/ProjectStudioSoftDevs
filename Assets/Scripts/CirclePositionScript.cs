using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CirclePositionScript : MonoBehaviour
{
    public RectTransform rectTransform;
    private float heightOffset = 208;
    private float widthOffset = 814;
    public Button button;
    private float duration;
    private GameManagerScript gameManagerScript;
    private ParticleSystem popParticles;
    
    // Start is called before the first frame update
    void Start()
    {
        popParticles = GameObject.FindGameObjectsWithTag("Particle")[0].GetComponent<ParticleSystem>();

        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        
        button.onClick.AddListener(destroyCircleWithPoint);
        
        float maxHeight = rectTransform.anchoredPosition.y + heightOffset;
        float minHeight = rectTransform.anchoredPosition.y - heightOffset;
        float minWidth = rectTransform.anchoredPosition.x - widthOffset;
        float maxWidth = rectTransform.anchoredPosition.x + widthOffset;
        
        rectTransform.anchoredPosition = new Vector2(Random.Range(minWidth, maxWidth), Random.Range(minHeight, maxHeight));
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
            gameManagerScript.loseHealth();
        }
    }

    public void destroyCircle()
    {
        Destroy(gameObject);
    }

    public void destroyCircleWithPoint()
    {
        destroyCircle();
        popParticles.Play();
        gameManagerScript.addScore();
    }
}
