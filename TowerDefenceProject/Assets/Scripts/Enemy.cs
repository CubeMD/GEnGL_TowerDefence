using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemySO enemyConfig;
    public Point target;
    public float hp;

    public float acceptanceRadius;
    
    private float speed;

    public void Start()
    {
        speed = enemyConfig.speed;
        hp = enemyConfig.hp;
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(Time.deltaTime * speed * Vector3.forward);
        transform.LookAt(target.transform);
        
        float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
        
        if (distanceToTarget < acceptanceRadius)
        {
            if (target.nextPoint != null)
            {
                target = target.nextPoint;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
