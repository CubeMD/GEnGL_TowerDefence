using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public TurretSO turretSO;

    Transform target;
    public Transform turretPivot;
    public Transform firePoint;

    public GameObject projectilePrefab;

    float fireCooldown = 0f;


    void Update()
    {
        if(target == null)
        {
            Collider[] enemies = Physics.OverlapSphere(transform.position, turretSO.range).Where(x => x.GetComponent<Enemy>() != null).ToArray();
            
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
            
            if(Vector3.Distance(transform.position, target.transform.position) > turretSO.range)
            {
                target = null;
            }
        }
        if (fireCooldown <= 0 && target != null)
        {
            Fire();
            fireCooldown = 1 / turretSO.fireRate;
        }


        fireCooldown -= Time.deltaTime;
    }

    public void Fire()
    {
        GameObject projectileGO = (GameObject)Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Projectile projectile = projectileGO.GetComponent<Projectile>();
        if(projectile != null)
        {
            projectile.FindTarget(target);
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, turretSO.range);
    }
}
