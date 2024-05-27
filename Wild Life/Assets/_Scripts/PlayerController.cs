using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    float horizontalInput;
    float verticalInput;

    float xRange = 15f;
    float upRangeZ = 15f;
    float downRangeZ = -0.5f;

    [SerializeField] GameObject projectilePrefab;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        PlayerMovement();
        CheckInBounds();
        Shoot();
    }

    void PlayerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
    }

    void CheckInBounds()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if(transform.position.z < downRangeZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, downRangeZ);
        }

        if(transform.position.z > upRangeZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, upRangeZ);
        }

    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Animals"))
        {
            Destroy(gameObject);
        }
    }

    

}

