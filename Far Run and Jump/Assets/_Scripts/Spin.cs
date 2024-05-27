using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spin : MonoBehaviour
{
    [SerializeField] float speedSpin;
    [SerializeField] float forceLeft;
    PlayerController _playerController;
    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    
    void Update()
    {
        if (!_playerController.GameOver)
        {
            transform.localPosition += Vector3.left * forceLeft * Time.deltaTime;
            //The same: transform.Translate(Vector3.left * forceLEft * Time.deltaTime;
            //Coordinates: local position with respect to the global of the GameObject considering its rotation!

            transform.Rotate(Vector3.up * speedSpin * Time.deltaTime);
        }
    }
}
