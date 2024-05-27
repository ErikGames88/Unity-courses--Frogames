using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Range(0,100), Tooltip("Top speed of the Car")] 
    float speed;
    [SerializeField, Range(0,90), Tooltip("Top turn speed of the car")]
    float turnSpeed;
    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        
    }

    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * horizontalInput);

    }
}
