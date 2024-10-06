using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossBullet : MonoBehaviour
{
    public EnemyWeapon FinalBossSkill;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerTrigger.Instance.CanTakeDamage(-FinalBossSkill.Damage);
        }
    }
}
