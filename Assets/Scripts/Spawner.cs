using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject towers;
    public GameObject fromwers;
    public GameObject atowers;
    public float spawnRate = 2f; 
    private float lastSpawnTime; 

    // Define the boundaries for the X positionawn
    public float minX = 15f; // Minimum X value for spawning
    public float maxX = 20f;  // Maximum X value for spawning

    void Start()
    {
        // Initial spawn (optional)
        SpawnTower();
    }

    void Update()
    {
        if (Time.time > lastSpawnTime + spawnRate)
        {
            SpawnTower();
            lastSpawnTime = Time.time;
        }
    }

    void SpawnTower()
    {
        // Generate a random X position within specified bounds
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, 8f, transform.position.z);

        // Instantiate the tower at the random position
        Instantiate(towers, spawnPosition, Quaternion.identity);
        Instantiate(atowers, spawnPosition, Quaternion.identity);
        Instantiate(fromwers, spawnPosition, Quaternion.identity);
    }
}
