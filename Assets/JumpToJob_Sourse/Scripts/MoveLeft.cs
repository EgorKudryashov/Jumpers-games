using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerController playerControllerScript;

    private float speed;
    private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        speed = playerControllerScript.gameSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameOver == false && gameManager.gameStart) 
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed * playerControllerScript.dashMode);
        }
        
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
