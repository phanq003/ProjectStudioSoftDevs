using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeScript : MonoBehaviour
{
    [SerializeField] private string shape;
    [SerializeField] private string colour;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string getShape()
    {
        return shape;
    }

    public string getColour()
    {
        return colour;
    }
}
