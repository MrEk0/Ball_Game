using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles;
    [SerializeField] GameSettings gameSettings;
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] float minTimeSpawn;
    [SerializeField] float maxTimeSpawn;

    float startSpeed;
    float additionalSpeed;
    float timeSinceLastSpawn=0f;
    int multIndex = 0;

    private void Awake()
    {
        startSpeed = gameSettings.GetStartSpeed();
    }

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<UIManager>().onScoreAchieved += UpdateSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceLastSpawn > timeBetweenSpawns)
        {
            int randObst = Random.Range(0, obstacles.Length);
            GameObject obs= Instantiate(obstacles[randObst], transform.position, Quaternion.identity);
            obs.GetComponent<Obstacle>().Speed = startSpeed+additionalSpeed;
            timeSinceLastSpawn = 0f;
            timeBetweenSpawns = Random.Range(minTimeSpawn, maxTimeSpawn);
        }
        timeSinceLastSpawn += Time.deltaTime;
    }

    private void UpdateSpeed()
    {
        additionalSpeed = startSpeed * gameSettings.GetSpeedMult(multIndex)-startSpeed;
        if (maxTimeSpawn - minTimeSpawn >= 2)
        {
            maxTimeSpawn -= 1.5f;
        }
        multIndex += 1;
    }
}
