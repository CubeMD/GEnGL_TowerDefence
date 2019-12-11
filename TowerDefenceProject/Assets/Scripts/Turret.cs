using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public Transform target;
    public float range;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //if (target != null)
        //{
            
        //}
    }
    public void UpdateTarget()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, range);
        if(enemies.Length > 1)
        {
            target = enemies[0].transform;
        }
        else
        {
            target = null;
        }
        
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
