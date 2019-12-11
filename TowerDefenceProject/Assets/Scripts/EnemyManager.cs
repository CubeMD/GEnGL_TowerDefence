using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public Point[] startingPoints;
    public float timeInterval;
    public GameObject[] enemies;
    
    // Start is called before the first frame update
    void Start()
    {
        startingPoints = FindObjectsOfType<Point>().Where(x => x.previousPoints.Count == 0).ToArray();
        StartCoroutine(SpawnEnemies());
    }

    public IEnumerator SpawnEnemies()
    {
        while (enemies.Length > 0)
        {
            Point spawnPoint = startingPoints[Random.Range(0, startingPoints.Length)];
            Vector3 spawnPos = spawnPoint.transform.position; 
            Enemy enemy = Instantiate(enemies[enemies.Length - 1], spawnPos, Quaternion.identity, transform).GetComponent<Enemy>(); 
            enemy.origin = spawnPoint; 
            enemy.target = spawnPoint.nextPoint;
            yield return new WaitForSeconds(timeInterval);
        }
    }
}
