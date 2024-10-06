using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    public GameObject EnemyPrefab;
    public int HP;
    public float Speed;
    public int BoddyDamage;
    public int Score;

}
