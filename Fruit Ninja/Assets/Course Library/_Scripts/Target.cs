using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody))]

public class Target : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float minForce = 12.0f, maxForce = 17.0f, 
        maxTorque = 10.0f, 
        xRange = 4.0f,
        ySpawnPos = -5;

    private GameManager gameManager;

    [SerializeField, Range(-100, 100)]
    int valuePoint;
    

    [SerializeField] ParticleSystem explosionParticle;

    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPosition();

        gameManager = FindObjectOfType<GameManager>();
        
    }

    
    void Update()
    {
        
    }

    /// <summary>
    /// Generate a aleatory Vector 3 in 3D
    /// </summary>
    /// <returns> A random Force up between 12 and 16 </returns>
    private Vector3 RandomForce()
    {
        float randomForce = Random.Range(minForce, maxForce);
        return Vector3.up * randomForce;
    }

    /// <summary>
    /// Generate a aleatory float number
    /// </summary>
    /// <returns> A random value between -10 and 10 to rotate the object when it'd be instantiated </returns>
    private float RandomTorque()
    {
        float randomTorque = Random.Range(-maxTorque, maxTorque);
        return randomTorque;
    }

    /// <summary>
    /// Generate a aleatory Vector3 for the position to spawn
    /// </summary>
    /// <returns> A random position where the X axis'll be between -4 and 4, and the Y axis'll be constantly -5. Z axis = 0 </returns>
    private Vector3 RandomSpawnPosition()
    {
        float randomPosX = Random.Range(-xRange, xRange);
        return new Vector3(randomPosX, ySpawnPos);
    }
    
    private void OnMouseDown()
    {
        if (gameManager.gameState == GameManager.GameState.inGame)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, transform.rotation);
            gameManager.UpdateScore(valuePoint);
        }

        if (gameObject.CompareTag("Bad2"))
        {
            gameManager.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sensor"))
        {
            Destroy(gameObject); 

            if (gameObject.CompareTag("Good"))
            {
                gameManager.UpdateScore(-10);
                gameManager.FallCount++;
                
                if (gameManager.FallCount > 5)
                {
                    gameManager.GameOver();
                }
            }
        }
    }
}
