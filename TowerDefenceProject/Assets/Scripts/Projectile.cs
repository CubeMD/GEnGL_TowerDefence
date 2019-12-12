using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectileSO projectileConfig;
    public Enemy target;
    
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        else
        {
            Vector3 direction = target.transform.position - transform.position;
            float distanceToTravel = projectileConfig.speed * Time.deltaTime;
            transform.Translate(direction.normalized * distanceToTravel, Space.World);
        
            if(direction.magnitude <= distanceToTravel)
            {
                Hit();
            }
        }
    }
    public void Hit()
    {
        target.hp -= projectileConfig.damage; 
        Destroy(gameObject);
    }
}
