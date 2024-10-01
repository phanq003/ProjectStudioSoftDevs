using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScoreSO : ScriptableObject
{
    [SerializeField]
    private int score;
    [SerializeField]
    private List<int> playerScores;
    [SerializeField]
    private int previousHoleScore;
    [SerializeField]
    private int holeCounter;
    public int Score { get { return score; } set { score = value; } }
    public int PreviousHoleScore { get { return previousHoleScore; } set { previousHoleScore = value; } }
    public List<int> PlayerScores { get { return playerScores; } set { playerScores = value; } }
    public int HoleCounter { get { return holeCounter; } set { holeCounter = value; } }
}
