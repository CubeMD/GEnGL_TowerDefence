using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public Transform target;
    public float range;

    void Update()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, range).Where(x => x.GetComponent<Enemy>() != null).ToArray();
        
        if (enemies.Length > 0)
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
