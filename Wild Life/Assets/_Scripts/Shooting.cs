using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] float speed;
    

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Animals"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

}

