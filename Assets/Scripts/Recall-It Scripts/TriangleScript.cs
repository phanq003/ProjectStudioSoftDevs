using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleScript : ShapeScript
{
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
}
