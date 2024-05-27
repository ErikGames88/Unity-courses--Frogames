using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset = new Vector3(20, 1.5f, 0);

    
    void Start()
    {

    }

    
    void Update()
    {
        transform.position = plane.transform.position + offset;
    }
}
