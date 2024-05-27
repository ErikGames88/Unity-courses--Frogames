using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    private float verticalInput;
    private float horizontalInput;


    void Start()
    {

    }

    
    void FixedUpdate()
    {
        
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        PlaneMovement();

    }

    void PlaneMovement()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * verticalInput);
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime * horizontalInput);
    }

    
}
