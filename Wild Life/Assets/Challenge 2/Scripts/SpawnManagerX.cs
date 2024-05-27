using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22f;
    private float spawnLimitXRight = 7f;
    private float spawnPosY = 30f;

    private int ballIndex;

    private float startDelay = 1.0f;
    [SerializeField] float randomRange1 = 1.5f;
    [SerializeField] float randomRange2 = 2.5f;
    

    
    void Start()
    {
        Invoke("SpawnRandomBall", startDelay);
    }

    
    void SpawnRandomBall()
    {
        
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        ballIndex = Random.Range(0, ballPrefabs.Length - 1);
        
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);

        startDelay = Random.Range(randomRange1, randomRange2);
        Invoke("SpawnRandomBall", startDelay);
    }

}
