using System.Collections;
using UnityEngine;

public class EnemyLowTrigger : MonoBehaviour
{
    public Enemy EnemyLow;
    public Animator Animator;
    DropItemsControl dropItemsControl;
    private bool isDeath = false;
    public bool canAttack;
    private int currentHP;
    private void OnEnable()
    {   
        dropItemsControl = GetComponent<DropItemsControl>();
    }
    private void Start()
    {
        currentHP = EnemyLow.HP;
    }
    private void OnDisable()
    {
        currentHP = EnemyLow.HP;
        canAttack = false;
        isDeath = false;
    }
    private void Update()
    {
        currentHP = Mathf.Clamp(currentHP, 0 , EnemyLow.HP);
        if (!isDeath)
        {
            if (currentHP == 0)
            {
                isDeath = true;
                SoundManager.Instance.PlaySound(6);
                GameManager.Instance.UpdateScore(EnemyLow.Score);
                dropItemsControl.DropRandomItem();          
                Animator.Play("EnemyLowDeath");
                StartCoroutine(EnemyDeath());
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        PlayerBulletTrigger playerBulletTrigger = collision.GetComponent<PlayerBulletTrigger>();
        ChaseBulletTrigger chaseBulletTrigger = collision.GetComponent<ChaseBulletTrigger>();
        if (collision.CompareTag("Player"))
        {
            PlayerTrigger.Instance.CanTakeDamage(-EnemyLow.BoddyDamage);
        }
        else if (collision.CompareTag("PlayerBullet"))
        {
            if (canAttack)
            {
                if (collision.gameObject.layer == LayerMask.NameToLayer("ChaseBullet"))
                {
                    SoundManager.Instance.PlaySound(7);
                    chaseBulletTrigger.GetDamage(ref currentHP);
                }
                if (collision.gameObject.layer == LayerMask.NameToLayer("Default"))
                {
                    SoundManager.Instance.PlaySound(7);
                    playerBulletTrigger.GetDamage(ref currentHP);
                }
            }
        }
    }
    IEnumerator EnemyDeath()
    {
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
    }
}
