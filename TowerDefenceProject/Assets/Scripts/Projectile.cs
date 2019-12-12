using UnityEngine;

public class Projectile : MonoBehaviour
{
    Transform target;
    public EnemySO enemy;
    public TurretSO turret;

    float projectileSpeed = 50;
    float distanceToTravel;

    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
        }

        Vector3 direction = target.position - transform.position;
        distanceToTravel = projectileSpeed * Time.deltaTime;
        transform.Translate(direction.normalized * distanceToTravel, Space.World);
        if(direction.magnitude <= distanceToTravel)
        {
            Hit();
        }
    }
    public void FindTarget(Transform currentTarget)
    {
        target = currentTarget;
    }
    public void Hit()
    {
        Destroy(gameObject);
        enemy.hp -= turret.damage;
    }
}
