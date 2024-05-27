using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerControllerX : MonoBehaviour
{
    private bool gameOver;
    public bool GameOver
    {
        get => gameOver;
        set => gameOver = value;
    }

    [SerializeField] float floatForce;
    [SerializeField] float gravityModifier = 1.5f;

    //Vector3 gravityConstant = new Vector3(0, -9.81f, 0);
    
    private Rigidbody playerRb;

    [SerializeField] ParticleSystem explosionParticle;
    [SerializeField] ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    [SerializeField] AudioClip moneySound;
    [SerializeField] AudioClip explodeSound;

    [SerializeField] float downGravity;

    private float topLimit = 15f;
    
    

    


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();

        


        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        FloatUp();
        Limits();
        
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
            Destroy(gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

    void FloatUp()
    {
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
            Physics.gravity = Vector3.down * downGravity;    
        }
    }

    void Limits()
    {
        if(transform.position.y > topLimit)
        {
            transform.position = new Vector3(transform.position.x, topLimit, transform.position.z);
            Physics.gravity = Vector3.down * downGravity;
        }
    }
}
