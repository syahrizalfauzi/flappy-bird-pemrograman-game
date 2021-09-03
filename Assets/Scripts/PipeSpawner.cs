using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] GameObject pipePrefab;
    [SerializeField] float maxYPosition = 6f;
    [SerializeField] float spawnInterval = 2f;
    float nextSpawn = 0f;

    void Update()
    {
        if (Time.time < nextSpawn)
            return;

        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + Random.Range(-maxYPosition, maxYPosition));
        GameObject.Instantiate(pipePrefab, spawnPosition, transform.rotation);
        nextSpawn = Time.time + spawnInterval;
    }
}
