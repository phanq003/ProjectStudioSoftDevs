using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoleManagerScript : MonoBehaviour
{
    public GameObject circle;
    private float spawnRate = 3;
    public Camera mainCamera;
    public GameObject mole;
    private float spawnRate = 2;
    private float timer = 0;
    private GameManagerScript gameManager;
    private List<GameObject> activeHoles;

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
        else if (gameManager.getHealthNumber() > 0 && gameManager.getTimeRemaining() > 0)
        {
            spawnMole();
            timer = 0;
        }
    }

    public void spawnMole()
    {
        Vector2 screenPostion = RectTransformUtility.WorldToScreenPoint(mainCamera, gameManager.selectHole().getPosition());
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(screenPostion.x, screenPostion.y, mainCamera.nearClipPlane));

        Instantiate(mole, new Vector3(worldPosition.x + 0.24748f, worldPosition.y + 0.43783f, 89), transform.rotation);

    }

    public void setSpawnRate(float number)
    {
        spawnRate -= number;
    }
    
    public float getSpawnRate()
    {
        return spawnRate;
    }

    public void allHolesActiveDelay()
    {
        timer = -2;
    }
}
