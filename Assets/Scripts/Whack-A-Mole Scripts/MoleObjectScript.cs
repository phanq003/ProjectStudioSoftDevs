using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoleObjectScript : MonoBehaviour
{
    private float duration;
    private GameManagerScript gameManager;
    public GameObject moleHit;
    private CursorManagerScript cursorManager;

//For festive switching
    public Sprite normalSprite;
    public Sprite christmasSprite;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        moleHit = Instantiate(moleHit, gameObject.transform.position, transform.rotation);
        cursorManager = GameObject.FindGameObjectWithTag("CursorManager").GetComponent<CursorManagerScript>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        setTheme(FestiveManager.instance.isFestive);
        
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
        if (!gameManager.gamePaused())
        {
            cursorManager.setCursorMalletHit();
            destroyMole();
            moleHit.SetActive(true);
            gameManager.addScore();
        }

        
    }

    public void destroyMole()
    {
        Destroy(gameObject);
    }

    public void setTheme(bool isFestive){
         if (isFestive == true)
        {
            spriteRenderer.sprite = christmasSprite; 
        }
        else
        {
            spriteRenderer.sprite = normalSprite; 
        }
    }
}
