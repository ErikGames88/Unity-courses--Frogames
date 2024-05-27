using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    Vector3 offset = new Vector3(0, 5.15f, -7);
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
