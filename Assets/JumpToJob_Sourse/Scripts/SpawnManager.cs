using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private Vector3 spawnPos= new Vector3(25,0,0);
    private float startDelay = 4;
    private float repeatRate = 2;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        InvokeRepeating("SpawnObstacles", startDelay, repeatRate);  
    }

    void SpawnObstacles()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefab.Length);
        if (gameManager.gameOver == false)
        {
            Instantiate(obstaclePrefab[obstacleIndex], spawnPos, obstaclePrefab[obstacleIndex].transform.rotation);
        }
    }
}
