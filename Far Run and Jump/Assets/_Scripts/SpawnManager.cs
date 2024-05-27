using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefabs;
    private Vector3 spawnPos;

    [SerializeField] float startDelay = 1.0f;
    [SerializeField] float rateSpawn = 2.0f;

    PlayerController _playerController;
    
    
    void Start()
    {
        //rateSpawn = Random.Range(2.0f, 3.0f);
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        spawnPos = transform.position;
        InvokeRepeating("RandomObstaclesSpawn", startDelay, rateSpawn);
    }

    void RandomObstaclesSpawn()
    {
        if (!_playerController.GameOver)
        {
            int randomIndex = Random.Range(0, obstaclePrefabs.Length);
            GameObject obstaclePrefab = obstaclePrefabs[randomIndex];

            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);

        }

        //Invoke("RandomObstaclesSpawn", rateSpawn);
        //InvokeRepeating("RandomObstaclesSpawn", startDelay, rateSpawn);
    }
    
}
