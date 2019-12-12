using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviour
{
    public List<WaveSO> waveConfig;
    public float spawnInterval;
    public float breakInterval;
    private Point[] startingPoints;
    private List<Dictionary<GameObject, int>> waves;
    
    private void Start()
    {
        startingPoints = FindObjectsOfType<Point>().Where(x => x.previousPoints.Count == 0).ToArray();
        waves = new List<Dictionary<GameObject, int>>();
        
        for (int i = 0; i < waveConfig.Count; i++)
        {
            Dictionary<GameObject, int> wave = new Dictionary<GameObject, int>();
            
            for (int j = 0; j < waveConfig[i].enemies.Count; j++)
            {
                wave.Add(waveConfig[i].enemies[j], waveConfig[i].correspondingAmounts[j]);
            }
            waves.Add(wave);
        }

        StartCoroutine(PlayWave());
    }

    private IEnumerator PlayWave()
    {
        for (int i = 0; i < waves.Count; i++)
        {
            GameManager.instance.RoundIncrease(i + 1);
            while (waves[i].Values.Sum() > 0)
            {
                Point spawnPoint = startingPoints[UnityEngine.Random.Range(0, startingPoints.Length)];
                Vector3 spawnPos = spawnPoint.transform.position;
                GameObject spawnEnemy = RandomEnemyFromWave(waves[i]);
                Enemy enemy = Instantiate(spawnEnemy, spawnPos, Quaternion.identity, transform).GetComponent<Enemy>();
                enemy.target = spawnPoint.nextPoint;
                yield return new WaitForSeconds(spawnInterval);
            }
            yield return new WaitForSeconds(breakInterval);
        }
        GameManager.instance.PlayerWin();
    }

    private static GameObject RandomEnemyFromWave(Dictionary<GameObject, int> wave)
    {
        int index = Random.Range(0, wave.Count);
        wave[wave.ElementAt(index).Key]--;
        return wave.ElementAt(index).Key;
    }
}
