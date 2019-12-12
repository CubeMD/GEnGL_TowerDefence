using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform turretPivot;
    public Transform target;
    //public List<Collider> enemies;

    public bool isTargeting = false;
    public float range;

    void Update()
    {
        if(target == null)
        {
            Collider[] enemies = Physics.OverlapSphere(transform.position, range).Where(x => x.GetComponent<Enemy>() != null).ToArray();
            
            if (enemies.Length > 0)
            {
                target = enemies[0].transform;
            }
        }
        else
        {
            Vector3 pointDirection = target.position - transform.position; 
            Quaternion LookRotation = Quaternion.LookRotation(pointDirection); 
            Vector3 turretRotation = LookRotation.eulerAngles;
            turretPivot.rotation = Quaternion.Euler(0, turretRotation.y, 0);
            
            if(Vector3.Distance(transform.position, target.transform.position) > range)
            {
                target = null;
            }
        }
        
        

        
        
        
        //if (enemies.Count > 0)
        //{
            
            
        //}
        //else
        //{
        //    target = null;
        //    isTargeting = false;
        //}

        

    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
