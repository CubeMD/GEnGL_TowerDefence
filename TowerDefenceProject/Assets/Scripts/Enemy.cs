using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemySO enemyConfig;
    public Point target;
    public float acceptanceRadius;
    public float hp;

    public void Start()
    {
        hp = enemyConfig.hp;
    }

    private void Update()
    {
        if (hp <= 0)
        {
            GameManager.instance.EnemyKilled();
            Destroy(gameObject);
        }
        
        Move();
    }

    public void Move()
    {
        transform.Translate(Time.deltaTime * enemyConfig.speed * Vector3.forward);
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
                GameManager.instance.PlayerTakenDamage();
                Destroy(gameObject);
            }
        }
    }
}
