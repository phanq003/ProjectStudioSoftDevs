using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BingoCardGenerator : MonoBehaviour
{
    public GameObject bingoCell;
    public Transform gridObj;
    public int gridSize = 5;

    private GridLayoutGroup gridLayoutGroup;


    // Start is called before the first frame update
    void Start()
    {
        //Sets the grid size of the layout to parameters
        gridLayoutGroup = gridObj.GetComponent<GridLayoutGroup>();
        gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayoutGroup.constraintCount = gridSize;

        //Generate bingo card cells
        GenerateBingoCard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateBingoCard(){
        for (int row = 0; row < gridSize; row++)
        {
            for (int col = 0; col < gridSize; col++)
            {
                // Instantiate a new cell from the prefab
                GameObject newCell = Instantiate(bingoCell, gridObj);

                // Generate a random value for this cell 
                int number = GetBingoValue(col);

                // Set the number in the cell's text component
                newCell.GetComponentInChildren<Text>().text = number.ToString();

                // Assign a name for identification
                newCell.name = $"Cell_{row}_{col}";
            }
        }
    }

    //TODO CHANGE TO WORDS
    int GetBingoValue(int column)
    {
        // Generates a number based on the column for Bingo (e.g., B: 1-15, I: 16-30, etc.)
        int min = column * 15 + 1;
        int max = (column + 1) * 15;
        return Random.Range(min, max + 1);
    }
}
