using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] float topBound = 50f;
    [SerializeField] float downBound = -40f;
    void Start()
    {
        
    }

    
    void Update()
    {
        bool cond1 = transform.position.z > topBound;
        bool cond2 = transform.position.z < downBound;
        if (cond1)
        {
            Destroy(gameObject);
        }

        if (cond2)
        {
            Debug.Log("G A M E    O V E R");
            Destroy(gameObject);

            Time.timeScale = 0f;
        }
    }
}

