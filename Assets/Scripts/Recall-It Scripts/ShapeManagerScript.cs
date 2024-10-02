using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject[] allShapes;
    private List<GameObject> usedShapes;
    private int shapesRecalled;
    [SerializeField] private PositionManagerScript positionManager;
    private float duration;
    private int recallInstance;
    private int MaxRecallInstance;
    [SerializeField] private float recallDelay;
    [SerializeField] private float hideDelay;
    private int recallCount;
    private bool isRecalling;

    public AudioSource beepSource;
    
    // Start is called before the first frame update
    void Start()
    {
        usedShapes = new List<GameObject>();
        shapesRecalled = 3;
        recallCount = 0;
        isRecalling = true;
        MaxRecallInstance = 3;
        recallInstance = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (duration < recallDelay)
        {
            duration += Time.deltaTime;
        }
        else if (recallCount < shapesRecalled)
        {
            startRecall();
            recallCount += 1;
            duration = 0f;
            beepSource.Play();
        }
        else if (isRecalling)
        {
            Debug.Log(shapesRecalled);
            Debug.Log("Recalling");
            isRecalling = false;
        }
    }

    public void startRecall()
    {
        if (recallInstance <= MaxRecallInstance)
        {
            int instance = 0;
            List<GameObject> randomShapes = new List<GameObject>();

            while (instance != recallInstance)
            {
                int randomShapeIndex = UnityEngine.Random.Range(0, allShapes.Length);

                if (!randomShapes.Contains(allShapes[randomShapeIndex]))
                {
                    randomShapes.Add(allShapes[randomShapeIndex]);
                    instance++;
                }
            }

            try
            {
                usedShapes.Add(Instantiate(randomShapes[0], new Vector3(positionManager.getMiddlePosition().x, positionManager.getMiddlePosition().y, positionManager.getMiddlePosition().z), transform.rotation));
                usedShapes.Add(Instantiate(randomShapes[1], new Vector3(positionManager.getFirstPosition().x, positionManager.getFirstPosition().y, positionManager.getFirstPosition().z), transform.rotation));
                usedShapes.Add(Instantiate(randomShapes[2], new Vector3(positionManager.getLastPosition().x, positionManager.getLastPosition().y, positionManager.getLastPosition().z), transform.rotation));
            }
            catch (ArgumentOutOfRangeException)
            {
                Debug.Log($"Instance: {recallInstance}");
            }
        }
    }

    public void nextRecall()
    {
        duration = 0f;
        recallCount = 0;
        isRecalling = true;
        resetRecall();
    }

    public void resetRecall()
    {
        foreach (GameObject shape in usedShapes)
        {
            Destroy(shape);
            
        }
        usedShapes.Clear();
    }

    public void increaseRecallInstance()
    {
        recallInstance = 3;
    }

    public void increaseShapesRecalled()
    {
        shapesRecalled++;
    }

    public void resetShapesRecalled()
    {
        shapesRecalled = 3;
    }
    
    public bool currentlyRecalling()
    {
        return isRecalling;
    }

    public List<GameObject> getUsedShapes()
    {
        return usedShapes;
    }
}
