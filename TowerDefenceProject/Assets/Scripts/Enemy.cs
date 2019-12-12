using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Point target;
    public Point origin;
    public float speed;
    public float hp;
    public float acceptanceRadius;

    private void Update()
    {
        transform.position += (target.transform.position - transform.position).normalized * speed * Time.deltaTime;
        //Debug.Log((target.transform.position - transform.position));
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
