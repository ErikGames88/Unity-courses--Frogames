using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] animals;
    int animalIndex;

    float spawnPosZ;
    float spawnRange = 14f;

    [SerializeField] float startDelay = 2f;
    [SerializeField, Range (0.5f, 2f)] float spawnRate = 1.5f;

    

    void Start()
    {
        spawnPosZ = transform.position.z;
        InvokeRepeating("SpawnAnimals", startDelay, spawnRate);
    }

    
    void Update()
    {
        
    }

    void SpawnAnimals()
    {
        float xRange = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(xRange, 0, spawnPosZ);
        animalIndex = Random.Range(0, animals.Length);

        Instantiate(animals[animalIndex], spawnPos, animals[animalIndex].transform.rotation);
    }
}
