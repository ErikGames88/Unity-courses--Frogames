using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float leftLimit = -35f;
    private float bottomLimit = -0.1f;

    
    void Update()
    {
        
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        } 
        
        if (transform.position.y <= bottomLimit)
        {
            Destroy(gameObject);
            Debug.Log("G A M E R   O V E R");
            Time.timeScale = 0f;
        }

    }
}
