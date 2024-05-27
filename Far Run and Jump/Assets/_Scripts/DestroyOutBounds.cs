using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutBounds : MonoBehaviour
{
    float limitToDestroy = -8.0f;

    private void Update()
    {
        if(transform.position.x < limitToDestroy)
        {
            Destroy(gameObject);
        }
    }
}
