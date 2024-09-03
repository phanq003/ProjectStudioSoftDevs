using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    private float duration;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (duration < 5)
        {
            duration += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
            duration = 0;
        }
    }
}
