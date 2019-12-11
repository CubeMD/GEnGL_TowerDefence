using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyManager : MonoBehaviour
{
    public Point[] startingPoints;
    public float timeInterval;
    
    // Start is called before the first frame update
    void Start()
    {
        startingPoints = FindObjectsOfType<Point>().Where(x => x.previousPoints.Count == 0).ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
