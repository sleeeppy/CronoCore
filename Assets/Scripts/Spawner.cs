using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;

    public float timer;
    public float Bosstimer;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();    
    }
    void Update()
    {
        timer += Time.deltaTime;
        Bosstimer += Time.deltaTime;
        if (timer > 0.8f)
        {
            timer = 0;
            Spawn();
        }
        if (Bosstimer > 10f)
        {
            SpawnBoss();
         }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(Random.Range(0, 2));
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }
    
    void SpawnBoss()
    {
        GameObject enemy = GameManager.instance.pool.Get(2);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        Bosstimer = 0;
    }
}
