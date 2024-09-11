using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecallGameManagerScript : MonoBehaviour
{
    [SerializeField] private int gameRounds;
    
    // Start is called before the first frame update
    void Start()
    [SerializeField] private ShapeManagerScript shapeManager;
    private int rampUpThresholdIncreaseShapesRecall;
    private int rampUpThresholdIncreaseShapeInstance;
    private int rampUpIntervals;
    private int MaxRampUp;


    private void Start()
    {
        
        rampUpIntervals = 2;
        rampUpThresholdIncreaseShapesRecall = rampUpIntervals;
        rampUpThresholdIncreaseShapeInstance = 6;
        MaxRampUp = 10;
    }
    void Update()
    {
        if (!shapeManager.currentlyRecalling() && !isQuestionGenerated && !waitingForAnswer && validHealth())
        {
        else if (hasAnswered && validHealth())
        {
            Debug.Log("Next");
            shapeManager.nextRecall();
    public void rampUp()
    {
        Debug.Log("Called");
        if (playerScore == rampUpThresholdIncreaseShapeInstance)
        {
            shapeManager.increaseRecallInstance();
            shapeManager.resetShapesRecalled();
            rampUpThresholdIncreaseShapesRecall += rampUpIntervals;
        }
        else if (playerScore == rampUpThresholdIncreaseShapesRecall && playerScore <= MaxRampUp)
        {
            shapeManager.increaseShapesRecalled();
            rampUpThresholdIncreaseShapesRecall += rampUpIntervals;
        }
    }
}
