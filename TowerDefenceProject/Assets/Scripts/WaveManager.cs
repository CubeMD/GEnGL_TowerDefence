using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviour
{
    public List<WaveSO> waveData;
    public float spawnInterval;
    public float breakInterval;
    private Point[] startingPoints;
    private List<Dictionary<GameObject, int>> waves;
    
    private void Start()
    {
        startingPoints = FindObjectsOfType<Point>().Where(x => x.previousPoints.Count == 0).ToArray();
        waves = new List<Dictionary<GameObject, int>>();
        
        for (int i = 0; i < waveData.Count; i++)
        {
            Dictionary<GameObject, int> wave = new Dictionary<GameObject, int>();
            
            for (int j = 0; j < waveData[i].enemies.Count; j++)
            {
                wave.Add(waveData[i].enemies[j], waveData[i].correspondingAmounts[j]);
            }
            waves.Add(wave);
        }

        StartCoroutine(PlayWave());
    }

    private IEnumerator PlayWave()
    {
        foreach (var wave in waves)
        {
            while (wave.Values.Sum() > 0)
            {
                Point spawnPoint = startingPoints[UnityEngine.Random.Range(0, startingPoints.Length)];
                Vector3 spawnPos = spawnPoint.transform.position;
                GameObject spawnEnemy = RandomEnemyFromWave(wave);
                Enemy enemy = Instantiate(spawnEnemy, spawnPos, Quaternion.identity, transform).GetComponent<Enemy>();
                enemy.target = spawnPoint.nextPoint;
                yield return new WaitForSeconds(spawnInterval);
            }
            yield return new WaitForSeconds(breakInterval);
        }
    }

    private static GameObject RandomEnemyFromWave(Dictionary<GameObject, int> wave)
    {
        int index = Random.Range(0, wave.Count);
        wave[wave.ElementAt(index).Key]--;
        return wave.ElementAt(index).Key;
    }
}
