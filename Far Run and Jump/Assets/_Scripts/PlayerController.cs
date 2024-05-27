using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    [SerializeField] float jumpSpeed;
    [SerializeField] float gravityMultiplier;
    bool isOnGround;
    private float speedController = 1;

    private bool gameOver; 
    public bool GameOver
    {
        get => gameOver;
        set => gameOver = value;
    }

    private Animator _animator;
    const string speedF = "Speed_f";
    const string speedMultiplier = "Speed Multiplier";
    const string deathB = "Death_b";
    const string jumpTrig = "Jump_trig";
    const string typeOfDeath = "DeathType_int";

    private int randomDeath;

    private Vector3 constantGravity = new Vector3(0, -9.81f, 0);

    [SerializeField] ParticleSystem explosion, dirtySplatter;

    [SerializeField] AudioClip jumpSound, crashSound;
    [SerializeField, Range(0,1)] float audioVolume = 1;
    

    private AudioSource _audioSource;
    


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity = gravityMultiplier * constantGravity; 
        _animator = GetComponent<Animator>();
        _animator.SetFloat(speedF, 1);
        dirtySplatter.Play();
        _audioSource = GetComponent<AudioSource>();

        randomDeath = Random.Range(1, 3);

    }

    
    void Update()
    {
        speedController += Time.deltaTime/10;
        _animator.SetFloat(speedMultiplier, speedController);

        PlayerJump();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtySplatter.Play();
        }

        if (collision.gameObject.CompareTag("Obstacles"))
        {
            gameOver = true;
            explosion.Play();
            _animator.SetBool(deathB, true);
            _animator.SetInteger(typeOfDeath, randomDeath);
            dirtySplatter.Stop();
            Destroy(collision.gameObject);
            _audioSource.PlayOneShot(crashSound, audioVolume);
            Physics.gravity = Vector3.down * 80;
            Invoke("RestartScene", 1.0f);
            
        }
    }

    void PlayerJump()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && !gameOver)
        {
            
            playerRb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse); //Force = Mass * Aceleration
            _animator.SetTrigger(jumpTrig);
            dirtySplatter.Stop();
            isOnGround = false;
            _audioSource.PlayOneShot(jumpSound, audioVolume);
        }
     }

    void RestartScene()
    {
        speedController = 1;
        SceneManager.LoadScene("Prototype 3");
    }
}
