using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeScript : MonoBehaviour
{
    [SerializeField] private string shape;
    [SerializeField] private string colour;
    [SerializeField] protected float hideDelay;
    protected float duration;
    protected bool isHidden;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (duration < hideDelay)
        {
            duration += Time.deltaTime;
        }
        else if (!isHidden)
        {
            gameObject.SetActive(false);
            isHidden = true;
        }
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
