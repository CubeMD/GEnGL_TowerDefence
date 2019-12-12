using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Turret SO", menuName = "Turret")]
public class TurretSO : ScriptableObject
{
    public float fireRate;
    public int cost;
    public float damage;
    public float range;
    public GameObject projectile;
}
