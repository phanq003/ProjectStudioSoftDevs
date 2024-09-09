using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject[] allShapes;
    private List<GameObject> usedShapes;
    [SerializeField] private int initialStartRecall;
    [SerializeField] private PositionManagerScript positionManager;
    private float duration;
    [SerializeField] private float recallDelay;
    [SerializeField] private float hideDelay;
    private int recallCount;
    // Start is called before the first frame update
    void Start()
    {
        usedShapes = new List<GameObject>();
        recallCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (duration < recallDelay)
        {
            duration += Time.deltaTime;
        }
        
        else if (recallCount < initialStartRecall)
        {
            startRecall();
            recallCount += 1;
            duration = 0f;
        }
    }

    public void startRecall()
    {
        int randomShapeIndex = Random.Range(0, allShapes.Length);
        GameObject randomShape = allShapes[randomShapeIndex];
        usedShapes.Add(Instantiate(randomShape, new Vector3(positionManager.getMiddlePosition().x, positionManager.getMiddlePosition().y, positionManager.getMiddlePosition().z), transform.rotation));
    }
}
