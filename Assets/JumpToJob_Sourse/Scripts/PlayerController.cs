using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;

    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem explosionPartical;
    public ParticleSystem dirtPartical;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    private float startPosition = 1;
    private float walkSpeed = 3.5f;
    public float gameSpeed = 30.0f;

    private float score;
    public TextMeshProUGUI scoreText;

    public float jumpForce;
    private int countJump;
    public int dashMode = 1;
    private bool onGround = true;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        score = 0;
        scoreText.text = "Score: " + score;

        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        countJump = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPosition)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * walkSpeed);
        }else
        {
            StartAnimation();
        }

        if (!gameManager.gameOver && gameManager.gameStart)
        {
            score += gameSpeed * Time.deltaTime * dashMode;
            score = Mathf.Ceil(score);
            scoreText.text = "Score: " + score;
        }

        PlayerJump();

        DashMode();
    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameManager.gameOver && countJump < 2 && gameManager.gameStart)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            dirtPartical.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            countJump++;
            onGround = false;
        }
    }
    private void DashMode()
    {
        if (Input.GetKey(KeyCode.RightArrow) && !gameManager.gameOver && onGround && gameManager.gameStart)
        {
            dashMode = 2;
            playerAnim.SetFloat("Dash_const", 2);

        }
        else
        {
            playerAnim.SetFloat("Dash_const", 1);
            dashMode = 1;
        }
    }
   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerAnim.ResetTrigger("Jump_trig");
            onGround = true;
            countJump = 0;
            dirtPartical.Play();
        }else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameManager.GameOver();

            score = Mathf.Ceil(score);
            scoreText.text ="Score: "+ score;

            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            dirtPartical.Stop();
            explosionPartical.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
        
    }

    void StartAnimation()
    {
        playerAnim.SetFloat("Speed_f", 1f);
        gameManager.gameStart = true;
    }
}
