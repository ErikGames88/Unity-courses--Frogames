using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    int enemyCount;
    int enemyWave = 1;

    [SerializeField] GameObject powerUpPrefab;
    

    void Start()
    {
        SpawnEnemyWave(enemyWave);
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
    }

    void Update()
    {
        enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0)
        {
            enemyWave++;
            SpawnEnemyWave(enemyWave);
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);

        }
    }

    /// <summary>
    /// Generate a random position within the game zone
    /// </summary>
    /// <returns> Return a random position within the game zone (randomPos of type Vector3) </returns>

    private Vector3 GenerateSpawnPosition()
    {
        float spawnRange = 9.0f;
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

    /// <summary>
    /// Generate a certain numbers of enemies in random positions thaks to the method GenerateSpawnPosition()
    /// <param name="numberOfEnemies"> Number of enemies to create</param>
    /// </summary>
    void SpawnEnemyWave(int numberOfEnemies)
    {
        for(int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    
}
