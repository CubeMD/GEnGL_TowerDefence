using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaveManager : MonoBehaviour
{
    public List<WaveSO> waveData;
    public int waveIndex;
    public Point[] startingPoints;

    public List<Dictionary<GameObject, int>> waves;
    
    private void Start()
    {
        startingPoints = FindObjectsOfType<Point>().Where(x => x.previousPoints.Count == 0).ToArray();
        
        for (int i = 0; i < waveData.Count; i++)
        {
            Dictionary<GameObject, int> wave = new Dictionary<GameObject, int>();
            
            for (int j = 0; j < waveData[i].enemies.Count; j++)
            {
                wave.Add(waveData[i].enemies[j], waveData[i].correspondingAmounts[j]);
            }
            waves.Add(wave);
        }
        /*PlayWave();*/
    }

/*    public void PlayWave()
    {
        StartCoroutine(SpawnWaveEnemies());
    }
    
    public IEnumerator SpawnWaveEnemies()
    {
        while (waves[waveIndex].Values.Sum() > 0)
        {
            Point spawnPoint = startingPoints[UnityEngine.Random.Range(0, startingPoints.Length)];
            Vector3 spawnPos = spawnPoint.transform.position; 
            Enemy enemy = Instantiate(waves[waveIndex]., spawnPos, Quaternion.identity, transform).GetComponent<Enemy>(); 
            enemy.origin = spawnPoint; 
            enemy.target = spawnPoint.nextPoint;
            enemies.RemoveAt(enemies.Count - 1);
            yield return new WaitForSeconds(timeInterval);
        }
    }*/
}
