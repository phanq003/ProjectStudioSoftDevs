using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BingoCard;
using JetBrains.Annotations;

public class BingoWinChecker : MonoBehaviour
{
    public GameObject bingoCard;
    public BingoCardGenerator bingoCardGen;
    public List<CellData> clickedCellsList;

    public List<List<Vector2Int>> winningPatterns;

    // Start is called before the first frame update
    void Start()
    {
       bingoCardGen = bingoCard.GetComponent<BingoCardGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onBingoClick(){
        clickedCellsList = bingoCardGen.clickedCellsList;
    }
}
