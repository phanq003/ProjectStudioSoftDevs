using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManagerScript : MonoBehaviour
{
    private string[] CountQuestions;
    private List<GameObject> usedShapes;
    private List<string> answerItems;
    private GameObject selectedShape;

    void Start()
    {
        CountQuestions = new string[] { "Shape", "Colour", "Shape&Colour"};
        usedShapes = new List<GameObject>();
        answerItems = new List<string>();
    }

    public string generateQuestion(List<GameObject> shapes)
    {
        usedShapes = shapes;
        string question = selectQuestion();
        selectedShape = selectShape();

        if (question.Equals("Shape"))
        {
            question = shapeQuestion();
        }
        else if (question.Equals("Colour"))
        {
            question = colourQuestion();
        }
        else if (question.Equals("Shape&Colour"))
        {
            question = shapeAndColourQuestion();
        }

        return question;
    }

    public void generateAnswer(string answer)
    {
        answerItems.Add(answer);
    }

    public int getGeneratedAnswer()
    {
        int count = 0;
        
        foreach (GameObject shape in usedShapes)
        {
            ShapeScript shapeScript = shape.GetComponent<ShapeScript>();

            if (answerItems.Count > 1)
            {
                if (shapeScript.getShape().Equals(answerItems[0]) && shapeScript.getColour().Equals(answerItems[1]))
                {
                    count++;
                }
            }
            else
            {
                if (shapeScript.getShape().Equals(answerItems[0]) || shapeScript.getColour().Equals(answerItems[0]))
                {
                    count++;
                }
            }
        }

        clearItems();
        
        return count;
    }

    public void clearItems()
    {
        answerItems.Clear();
    }

    public string selectQuestion()
    {
        int randomQuestion = Random.Range(0, CountQuestions.Length);
        string question = CountQuestions[randomQuestion];

        // Interface Question Set Here...

        return question;
    }

    public GameObject selectShape()
    {
        int randomShape = Random.Range(0, usedShapes.Count);
        GameObject shape = usedShapes[randomShape];

        return shape;
    }

    public string shapeQuestion()
    {
        ShapeScript shapeScript = selectedShape.GetComponent<ShapeScript>();
        string shape = shapeScript.getShape();

        generateAnswer(shape);

        string shapeQuestion = $"How many \"{shape}s\" appeared?";

        return shapeQuestion;
    }
    
    public string colourQuestion()
    {
        ShapeScript shapeScript = selectedShape.GetComponent<ShapeScript>();
        string colour = shapeScript.getColour();

        generateAnswer(colour);

        string colourQuestion = $"How many times has the colour \"{colour}\" appeared?";

        return colourQuestion;
    }

    public string shapeAndColourQuestion()
    {
        ShapeScript shapeScript = selectedShape.GetComponent<ShapeScript>();
        string shape = shapeScript.getShape();
        generateAnswer(shape);

        string colour = shapeScript.getColour();
        generateAnswer(colour);

        string shapeAndColourQuestion = $"How many \"{shape}s\" with the colour \"{colour}\" appeared?";

        return shapeAndColourQuestion;
    }
}
