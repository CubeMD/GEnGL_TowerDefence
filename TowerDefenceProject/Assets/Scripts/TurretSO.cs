using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTurretSO", menuName = "Turret")]
public class TurretSO : ScriptableObject
{
    public float fireRate;
    public int cost;
    public float range;
    public GameObject projectile;
}
