﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
    public float speed;
    private GameManagerX gameManager;
    private float leftBound = -10;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
    }

    // Update is called once per frame
    void Update()
    {
        // If game is not over, move to the left
        if (!gameManager.gameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }

        // If object goes off screen that is NOT the background, destroy it
        if (transform.position.x < leftBound && ((gameObject.CompareTag("Bomb")) || (gameObject.CompareTag("Money"))))
        {
            Destroy(gameObject);
        }

    }
}
