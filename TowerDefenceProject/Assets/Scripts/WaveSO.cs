using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWaveSO", menuName = "Wave")]
public class WaveSO : ScriptableObject
{
    public float spawnInterval;
    
    public List<GameObject> enemies;
    public List<int> correspondingAmounts;
}
