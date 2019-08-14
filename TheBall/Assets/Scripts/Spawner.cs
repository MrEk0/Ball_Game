using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles;
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] float minTimeSpawn;
    [SerializeField] float maxTimeSpawn;

    float timeSinceLastSpawn=0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceLastSpawn > timeBetweenSpawns)
        {
            int randObst = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[randObst], transform.position, Quaternion.identity);
            timeSinceLastSpawn = 0f;
            timeBetweenSpawns = Random.Range(minTimeSpawn, maxTimeSpawn);
        }
        timeSinceLastSpawn += Time.deltaTime;
    }
}
