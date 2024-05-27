using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float speed;

    PlayerController _playerController;


    void Start() 
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }



    void Update()
    {
        if (!_playerController.GameOver) //if (_playerController.gameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
