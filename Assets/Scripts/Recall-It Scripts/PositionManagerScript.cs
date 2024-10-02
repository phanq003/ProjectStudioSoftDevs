using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManagerScript : MonoBehaviour
{
    [SerializeField] private Vector3[] positions;
    
    public Vector3 getFirstPosition()
    {
        return positions[0];
    }

    public Vector3 getMiddlePosition()
    {
        return positions[positions.Length / 2];
    }

    public Vector3 getLastPosition()
    {
        return positions[positions.Length - 1];
    }
}
