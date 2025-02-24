using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy; 
    public Transform player; 
    public float DistancePlayer = 10f; 
    public float Range = 20f; 
    public float spawnInterval = 2f; 

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        if (spawnPosition != Vector3.zero) 
        {
            Instantiate(Enemy, spawnPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPosition;
        int attempts = 0;
        do
        {
           
            Vector2 randomCircle = Random.insideUnitCircle * Range;
            spawnPosition = new Vector3(randomCircle.x, 0f, randomCircle.y) + transform.position;

            attempts++;
            if (attempts > 100) 
            {
                return Vector3.zero; 
            }
        } while (Vector3.Distance(spawnPosition, player.position) < DistancePlayer);

        return spawnPosition;
    }

}