using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossTrigger : MonoBehaviour
{
    public Enemy FinalBoss;
    public Animator Animator;
    public GameObject FinalBossEngine;
    public FinalBossControler FinalBossControl;
    private int currentHP;
    private bool isDeath = false;
    
    private void Start()
    {
        currentHP = FinalBoss.HP;
    }
    private void OnDisable()
    {
        currentHP = FinalBoss.HP;
    }
    private void Update()
    {
        currentHP = Mathf.Clamp(currentHP, 0, FinalBoss.HP);
        if (!isDeath)
        {
            if (currentHP == 0)
            {
                isDeath = true;
                SoundManager.Instance.PlaySound(2);
                GameManager.Instance.UpdateScore(FinalBoss.Score);
                FinalBossControl.StopBoss();
                Animator.Play("FinalBossDeath");
                StartCoroutine(EnemyDeath());
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBulletTrigger playerBulletTrigger = collision.GetComponent<PlayerBulletTrigger>();
        ChaseBulletTrigger chaseBulletTrigger = collision.GetComponent<ChaseBulletTrigger>();
        if (Level4.Instance.start)
        {
            if (collision.CompareTag("PlayerBullet"))
            {
                if (collision.gameObject.layer == LayerMask.NameToLayer("ChaseBullet"))
                {
                    chaseBulletTrigger.GetDamage(ref currentHP);
                }
                if (collision.gameObject.layer == LayerMask.NameToLayer("Default"))
                {
                    playerBulletTrigger.GetDamage(ref currentHP);
                }
            }
            else if (collision.CompareTag("Player"))
            {
                PlayerTrigger.Instance.CanTakeDamage(-FinalBoss.BoddyDamage);
            }
        }
        
    }
    IEnumerator EnemyDeath()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
