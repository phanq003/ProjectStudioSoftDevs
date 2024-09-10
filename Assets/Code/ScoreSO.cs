using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScoreSO : ScriptableObject
{
    [SerializeField]
    private int score;

    public int Score { get {return score;} set { score = value; } }
}
