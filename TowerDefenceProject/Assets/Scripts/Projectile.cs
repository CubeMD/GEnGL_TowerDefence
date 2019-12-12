using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Enemy target;

    float projectileSpeed = 50;
    float distanceToTravel;

    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
        }

        Vector3 direction = target.transform.position - transform.position;
        distanceToTravel = projectileSpeed * Time.deltaTime;
        transform.Translate(direction.normalized * distanceToTravel, Space.World);
        
        if(direction.magnitude <= distanceToTravel)
        {
            Hit();
        }
    }
    public void Hit()
    {
        Destroy(gameObject);
        //enemy.hp -= turret.damage;
    }
}
