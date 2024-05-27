using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    Rigidbody _rigidbody;
    [SerializeField] float moveForce;

    GameObject player;

    float yLimit = 22;
    float xLimit = 35;
    float zLimit = 65;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - this.transform.position).normalized; 

        _rigidbody.AddForce(moveForce * lookDirection, ForceMode.Force);

        DestroyEnemyOutBounds();
    }

    void DestroyEnemyOutBounds()
    {
        if (transform.position.y < -yLimit || transform.position.x < -xLimit || transform.position.x > xLimit ||
            transform.position.z < -zLimit || transform.position.z > zLimit)
        {
            Destroy(gameObject);
        }
    }
}
