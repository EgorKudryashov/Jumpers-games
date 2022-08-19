using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private GameManagerX gameManager;

    private float topBound = 15f;
    private float lowerBound = 1f;

    public float floatForce;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManagerX>();

        playerRb = GetComponent<Rigidbody>();

        playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameManager.gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        } 

        if (transform.position.y > topBound)
        {
            transform.position = new Vector3(transform.position.x, topBound, transform.position.z);
            playerRb.AddForce(Vector3.down * 3, ForceMode.Impulse);
        }

        if (transform.position.y < lowerBound)
        {
            transform.position = new Vector3(transform.position.x, lowerBound, transform.position.z);
            playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);

            gameManager.GameOver();

            Destroy(other.gameObject);
            Invoke("DestroyPlayer", 2f);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);

            gameManager.UpdateScore();

            Destroy(other.gameObject);

        }

    }

    void DestroyPlayer()
    {
        gameObject.SetActive(false);
    }

}
