using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace BingoCard{
    public class BingoCardGenerator : MonoBehaviour
    {
        public GameObject bingoCell;
        public Transform gridObj;
        public int gridSize = 5;
        public List<string> possibleVals; 
        public List<string> valuesInGrid; //TODO Move this to be a local var??

        public List<CellData> clickedCellsList = new List<CellData>();


        // public List<string> selectedValues;
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
                    //Instantiate a new cell from the prefab
                    GameObject newCell = Instantiate(bingoCell, gridObj);

                    //Generate a random value for this cell 
                    string value = GetBingoValue(col);

                    //Set the number in the cell's text component
                    newCell.GetComponentInChildren<Text>().text = value;

                    //Assign a name for identification
                    newCell.name = $"Cell_{row}_{col}";
                    
                    //Adds a listener so that when the button is clicked, it passes Vector and cell obj to onCellClick() method
                    //make new instances of vars
                    int currentRow = row;
                    int currentCol = col;
                    newCell.GetComponent<Button>().onClick.AddListener(() => onCellClick(new Vector2Int(currentCol,currentRow), newCell));

            }
            }
        }

        string GetBingoValue(int column) {
            //Sets the range of words that the column will cover (e.g. col 0 covers first 5th of list in a 5x5 grid, col 1 second 5th)
            int listSize = possibleVals.Count;
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

            //Sorts the list alphabetically so grid can be generated alphabetically
            possibleVals = possibleVals.OrderBy(i => i).ToList();
            
        }

        void onCellClick(Vector2Int location, GameObject content){

            CellData clickedCell = new CellData(location, content);

            if(clickedCellsList.Contains(clickedCell)){
                clickedCell.content.GetComponent<Image>().color = Color.white;
                clickedCellsList.Remove(clickedCell);
                Debug.Log("Cell UnClicked: " + clickedCellsList.Count);
            }
            else{
                clickedCell.content.GetComponent<Image>().color = new Color(0.7f,1,0.66f);
                clickedCellsList.Add(clickedCell);
                Debug.Log("Cell Clicked: " + clickedCellsList.Count);

            }
        }

        
    }

    public class CellData{
        public Vector2Int location;
        public GameObject content;

        public CellData(Vector2Int location, GameObject content){
            this.location = location;
            this.content = content;
        }

        //Overriding Equals and Hashcode so that .contains works on the list
        public override bool Equals(object obj){
        
            if (obj is CellData other){ //Checks if is CellData then casts it
            
                return this.location == other.location && this.content == other.content;
            }
            return false;
        }

        public override int GetHashCode(){
                //Using the primitive values so it works correctly
                int hash = 0;
                hash += location.x.GetHashCode();
                hash += location.y.GetHashCode();
                hash += content.name.GetHashCode(); 
                return hash;
            
        }
    }
}
