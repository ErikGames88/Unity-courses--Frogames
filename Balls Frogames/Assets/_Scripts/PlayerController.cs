using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private float forwardInput;
    [SerializeField] float moveForce;
    
    private GameObject focalPoint;

    bool hasPowerUp;
    [SerializeField] float powerUpForce;
    private float powerUpTime = 8.0f;
    [SerializeField] GameObject[] powerUpIndicators;

    //float yLimit = 22;
    //float xLimit = 35;
    //float zLimit = 65;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point"); 
    }

    
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");

        //Local or relative coordinates of Game Object Focal Point got in Start method
        //Main Camera as child of Focal Point has a transform regarding its father (Spining Focal Point but Main Camera is fixed)
        _rigidbody.AddForce(focalPoint.transform.forward * forwardInput * moveForce, ForceMode.Force);

        foreach(GameObject indicator in powerUpIndicators)
        {
            indicator.transform.position = this.transform.position + Vector3.down * 0.25f;
        }

        //RestartScene();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Power Up"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDown());
        }

        if(other.name.CompareTo("Kill Zone") == 0) //("Kill Zone") == 0 --> The other collider is named Kill Zone
        {
            SceneManager.LoadScene("Prototype 4");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - this.transform.position;
            
            enemyRigidbody.AddForce(awayFromPlayer * powerUpForce, ForceMode.Impulse);
        }

    }

    /*void RestartScene()
    {
        if (transform.position.y < -yLimit || transform.position.x < -xLimit || transform.position.x > xLimit ||
            transform.position.z < -zLimit || transform.position.z > zLimit)
        {
            SceneManager.LoadScene("Prototype 4");
        }
    }*/

    IEnumerator PowerUpCountDown() //Coroutine
    {
        foreach(GameObject indicator in powerUpIndicators)
        {
            indicator.gameObject.SetActive(true);
            yield return new WaitForSeconds(powerUpTime / powerUpIndicators.Length);
            indicator.gameObject.SetActive(false);
        }

        /*for(int i = 0; i < powerUpIndicators.Length; i++)
        {
            powerUpIndicators[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(powerUpTime / powerUpIndicators.Length);
            powerUpIndicators[i].gameObject.SetActive(false);
        }*/
        
        hasPowerUp = false;
    }
}
