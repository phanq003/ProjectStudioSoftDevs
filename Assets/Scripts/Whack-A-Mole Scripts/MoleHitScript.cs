using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleHitScript : MonoBehaviour
{

    [SerializeField] private float delay = 0.5f;
    private float duration;

    void Update()
    {
        if (duration < delay)
        {
            duration += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
