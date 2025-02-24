/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject Enemies;
    [SerializeField] private GameObject player;
    [SerializeField] private float spawnRate;
    [SerializeField] private float rangeMin;

    void Start()
    {
        StartCoroutine(Spawning());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Spawning()
    {
        GameObject Enemies = Instantiate(Enemies, location)
        yield return new WaitForSeconds(spawnRate);
        StartCoroutine(Spawning());
    }
}
*/