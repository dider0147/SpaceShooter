using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyWeapon", menuName = "EnemyWeapon")]
public class EnemyWeapon : ScriptableObject
{
    public GameObject EnemyWeaponPrefab;
    public float speed;
    public int Damage;
    
}
