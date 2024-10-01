using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
    public Animator holeEntry;
    public RectTransform holePosition;
    private bool isOccupied = false;
    [SerializeField] private float occupiedDuration = 1.5f;
    private float timer;

    public void playEntryAnimation()
    {
        holeEntry.enabled = true;
    }

    public Vector3 getPosition()
    {
        return holePosition.position;
    }

    public void setOccupied()
    {
        isOccupied = true;
    }

    public bool isCurrentlyOccupied()
    {
        return isOccupied;
    }

    void Update()
    {
        if (timer < occupiedDuration && isOccupied)
        {
            timer += Time.deltaTime;
        }
        else
        {
            isOccupied = false;
            timer = 0;
        }
    }
}
