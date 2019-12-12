using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSO : ScriptableObject
{
    public float spawnInterval;
    
    public List<Enemy> enemies;
    public List<int> correspondingAmounts;
}
