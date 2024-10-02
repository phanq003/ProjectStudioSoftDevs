using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BingoCard;
using JetBrains.Annotations;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BingoWinChecker : MonoBehaviour
{

/*
Still needs to be done:
- Match win patterns with the actual words being displayed
- Disable other stuff when win screen is presented
- Replay Functionality/ make  it have menus
*/

    public GameObject bingoCard;
    public BingoCardGenerator bingoCardGen;
    public BingoDrawGenerator bingoDrawGen;
    public List<List<Vector2Int>> winningPatterns = new List<List<Vector2Int>>();
    public GameObject winOverlay;
    public GameObject falsiePopup;

    public AudioSource bingo;
    public AudioSource buzzer;

    // private List<CellData> clickedCellsList = new List<CellData>();
    private int gridSize;

    void Awake(){
        winOverlay.SetActive(false);
        falsiePopup.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
       bingoCardGen = bingoCard.GetComponent<BingoCardGenerator>();
       gridSize = bingoCardGen.gridSize;

       defineWinPatterns();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onBingoClick(){ //WIP
        Debug.Log("ClickedCellsCount: " + bingoCardGen.clickedCellsList.Count);
        checkForBingo(bingoCardGen.clickedCellsList);
    }

    bool checkForBingo(List<CellData> clickedCellsList){
        List<string> drawnVals = bingoDrawGen.drawnVals;
        foreach (List<Vector2Int> pattern in winningPatterns){
            bool isBingo = true;
            foreach (Vector2Int coord in pattern){
                if (!checkCoordsInClicked(coord, clickedCellsList, drawnVals)){
                    isBingo = false;
                    break;
                }

            }

            if (isBingo){
                bingo.Play();  
                Debug.Log("Is Bingo");
                winOverlay.SetActive(true);
                Time.timeScale = 0.0f;

                return true;
            }
        }
        buzzer.Play();
        Debug.Log("No Bingo");
        StartCoroutine(FalsieDisplay());
        return false;
    }

    IEnumerator FalsieDisplay(){
        falsiePopup.SetActive(true);
        yield return new WaitForSeconds(5);
        falsiePopup.SetActive(false);
    }

    bool checkCoordsInClicked(Vector2Int coord, List<CellData> clickedCellsList, List<string> drawnVals){
        foreach (CellData cell in clickedCellsList){

            // Debug.Log("Cell coords: " + cell.location.x + " " + cell.location.y + ". Checked: " + coord.x + " " +  coord.y  );
            if (cell.location.x == coord.x && cell.location.y == coord.y ){
                // Debug.Log("Coords Found");
                if (drawnVals.Contains(cell.content.GetComponentInChildren<Text>().text)){
                    return true;
                }
            }
        }
        return false;
    }

    void defineWinPatterns(){
        // Row patterns
        for (int row = 0; row < gridSize; row++){
            List<Vector2Int> rowPattern = new List<Vector2Int>();
            for (int col = 0; col < gridSize; col++)
            {
                rowPattern.Add(new Vector2Int(row, col));
            }
            winningPatterns.Add(rowPattern);
        }

        //Column patterns
        for (int col = 0; col < gridSize; col++){
            List<Vector2Int> colPattern = new List<Vector2Int>();
            for (int row = 0; row < gridSize; row++)
            {
                colPattern.Add(new Vector2Int(row, col));
            }
            winningPatterns.Add(colPattern);
        }

        //Diagonal pattern (top left to bottom right)
        List<Vector2Int> diagonalPattern1 = new List<Vector2Int>();
        for (int i = 0; i < gridSize; i++){
            diagonalPattern1.Add(new Vector2Int(i, i));
        }
        winningPatterns.Add(diagonalPattern1);

        //Diagonal pattern (top right to bottom left)
        List<Vector2Int> diagonalPattern2 = new List<Vector2Int>();
        for (int i = 0; i < gridSize; i++){
            diagonalPattern2.Add(new Vector2Int(i, gridSize - i - 1)); //gridSize - i - 1 starts from right side of grid to work inwards, -1 because index starts at 0 
        }
        winningPatterns.Add(diagonalPattern2);
    }

     public void quitGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("GameSelectScene");
    }
}
