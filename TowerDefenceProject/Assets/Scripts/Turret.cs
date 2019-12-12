using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public TurretSO turretConfig;
    public Transform turretPivot;
    public Transform firePoint;
    private Transform target;
    private float timer;

    void Update()
    {
        if(target == null)
        {
            Collider[] enemies = Physics.OverlapSphere(transform.position, turretConfig.range).Where(x => x.GetComponent<Enemy>() != null).ToArray();
            
            if (enemies.Length > 0)
            {
                target = enemies[0].transform;
            }
        }
        else
        {
            Vector3 pointDirection = target.position - transform.position; 
            Quaternion lookRotation = Quaternion.LookRotation(pointDirection); 
            Vector3 turretRotation = lookRotation.eulerAngles;
            turretPivot.rotation = Quaternion.Euler(0, turretRotation.y, 0);
            
            if (timer >= turretConfig.fireRate)
            {
                Fire();
                timer = 0;
            }
            
            if(Vector3.Distance(transform.position, target.transform.position) > turretConfig.range)
            {
                target = null;
            }
        }
        
        timer += Time.deltaTime;
    }

    private void Fire()
    {
        Projectile projectile = Instantiate(turretConfig.projectile, firePoint.position, firePoint.rotation).GetComponent<Projectile>();
        projectile.target = target.GetComponent<Enemy>();
    }

    public void OnDrawGizmos()
    {
        if (turretConfig)
        {
            Gizmos.DrawWireSphere(transform.position, turretConfig.range);
        }
    }
}
