using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


public class BingoCardGenerator : MonoBehaviour
{
    public GameObject bingoCell;
    public Transform gridObj;
    public int gridSize = 5;
    public List<string> possibleVals; 
    public List<string> valuesInGrid;
    public List<string> selectedValues;
    public BingoDrawGenerator drawGenerator;
    private GridLayoutGroup gridLayoutGroup;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the grid size of the layout to parameters
        gridLayoutGroup = gridObj.GetComponent<GridLayoutGroup>();
        gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayoutGroup.constraintCount = gridSize;

        //Get possible values for cells
        setBingoVals();
        //Generate bingo card cells
        generateBingoCard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generateBingoCard(){
        for (int row = 0; row < gridSize; row++)
        {
            for (int col = 0; col < gridSize; col++)
            {
                // Instantiate a new cell from the prefab
                GameObject newCell = Instantiate(bingoCell, gridObj);

                // Generate a random value for this cell 
                string value = GetBingoValue(col);

                // Set the number in the cell's text component
                newCell.GetComponentInChildren<Text>().text = value;

                // Assign a name for identification
                newCell.name = $"Cell_{row}_{col}";
                Debug.Log(newCell.name + ": " + newCell.GetComponentInChildren<Text>().text);
            }
        }
    }

    string GetBingoValue(int column) {
        //Sets the range of words that the column will cover (e.g. col 0 covers first 5th of list in a 5x5 grid, col 1 second 5th)
        int listSize = possibleVals.Count;
        Debug.Log(listSize);
        int min = (listSize/gridSize) * (column + 1) - (listSize/gridSize);
        int max;
        if (column == gridSize-1){ //in the case listsize is uneven so sets the final column to cover all remaining words
            max = listSize; 
        }
        else{
            max = (listSize/gridSize) * (column + 1); //Not doing minus 1 because Random is exclusive of Max
        }

        int randomVal = Random.Range(min, max);
        //Duplication detection, only if the list is large enough to have unique items in each cell
        if (Mathf.Abs(min-max) >= gridSize){ 
            for (int i = 0; i < gridSize; i++){ //Using a for loop in the case that there are duplicates in list but not enough unique items to fill grid
                if (!valuesInGrid.Contains(possibleVals[randomVal])){
                    valuesInGrid.Add(possibleVals[randomVal]);
                    break;
                }
                else {
                    randomVal = Random.Range(min, max);
                }
            }
        }

        return possibleVals[randomVal];   
    }



    void setBingoVals(){
        possibleVals = drawGenerator.possibleVals;
        Debug.Log(drawGenerator.possibleVals.Count);

        //Sorts the list alphabetically so grid can be generated alphabetically
        possibleVals = possibleVals.OrderBy(i => i).ToList();
        
    }
}
