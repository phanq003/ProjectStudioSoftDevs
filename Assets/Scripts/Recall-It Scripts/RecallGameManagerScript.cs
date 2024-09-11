using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecallGameManagerScript : MonoBehaviour
{
    [SerializeField] private int gameRounds;
    [SerializeField] private RecallGameUIScript gameUI;
    [SerializeField] private ShapeManagerScript shapeManager;
    [SerializeField] private QuestionManagerScript questionManager;
    private bool isQuestionGenerated;
    private string generatedQuestion;
    private bool hasAnswered;
    private bool waitingForAnswer;
    private int correctAnswer;
    private int rampUpThresholdIncreaseShapesRecall;
    private int rampUpThresholdIncreaseShapeInstance;
    private int rampUpIntervals;
    private int MaxRampUp;


    private void Start()
    {
        isQuestionGenerated = false;
        waitingForAnswer = false;
        hasAnswered = false;
        rampUpIntervals = 2;
        rampUpThresholdIncreaseShapesRecall = rampUpIntervals;
        rampUpThresholdIncreaseShapeInstance = 6;
        MaxRampUp = 10;
    }
    void Update()
    {
        if (!shapeManager.currentlyRecalling() && !isQuestionGenerated && !waitingForAnswer && validHealth())
        {
            Debug.Log("Gen");
            generatedQuestion = questionManager.generateQuestion(shapeManager.getUsedShapes());
            isQuestionGenerated = true;
            waitingForAnswer = true;
        }
        else if (isQuestionGenerated && validHealth())
        {
            Debug.Log("Dis");
            gameUI.updateQuestion(generatedQuestion);
            gameUI.displayQuestion();
            correctAnswer = questionManager.getGeneratedAnswer();
            gameUI.updateAnswers(correctAnswer);
            isQuestionGenerated = false;
        }
        else if (hasAnswered && validHealth())
        {
            Debug.Log("Next");
            waitingForAnswer = false;
            hasAnswered = false;
            shapeManager.nextRecall();
            gameUI.hideQuestionDisplay();
        }

    }
    public void answer1Clicked()
    {
        compareAnswer(gameUI.getPopulatedAnswers()[0]);
        playerHasAnswered();
    }

    public void answer2Clicked()
    {
        compareAnswer(gameUI.getPopulatedAnswers()[1]);
        playerHasAnswered();
    }

    public void answer3Clicked()
    {
        compareAnswer(gameUI.getPopulatedAnswers()[2]);
        playerHasAnswered();
    }

    public void playerHasAnswered()
    {
        hasAnswered = true;
    }

    public void compareAnswer(string answer)
    {
        Debug.Log($"Correct: {correctAnswer}");
        if (answer.Equals(correctAnswer.ToString()))
        {
            Debug.Log("Correct");

        }
    }

    public bool getHasAnswered()
    {
        return hasAnswered;
    }

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
