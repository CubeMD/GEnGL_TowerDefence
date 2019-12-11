using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Point target;
    public float speed;
    public float hp;
    public float acceptanceRadius;

    private void Update()
    {
        //transform.LookAt(target.transform);
        transform.Translate(speed * Time.deltaTime * (target.transform.position - transform.position));
        
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
