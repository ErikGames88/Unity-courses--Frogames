using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    [SerializeField] float speedTurning;
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * speedTurning);
    }
}
