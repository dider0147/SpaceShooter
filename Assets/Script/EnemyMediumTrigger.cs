using System.Collections;
using UnityEngine;

public class EnemyMediumTrigger : MonoBehaviour
{
    public Enemy EnemyMedium;
    public Animator Animator;
    public GameObject EnemyMediumEngine;
    public EnemyMediumMovement EnemyMediumMovement;
    private DropItemsControl DropItemsControl;
    private int currentHP;
    private bool isDeath = false;
    private void OnEnable()
    {
        DropItemsControl = GetComponent<DropItemsControl>();
    }
    private void Start()
    {
        currentHP = EnemyMedium.HP;
    }
    private void OnDisable()
    {
        currentHP = EnemyMedium.HP;
        isDeath = false;
    }
    private void Update()
    {   
        currentHP = Mathf.Clamp(currentHP, 0, EnemyMedium.HP);
        if (!isDeath)
        {   
            if (currentHP == 0)
            {   
                isDeath = true;
                SoundManager.Instance.PlaySound(10);
                GameManager.Instance.UpdateScore(EnemyMedium.Score);
                DropItemsControl.DropRandomItem();
                EnemyMediumMovement.StopEnemy();
                Animator.Play("EnemyMediumDeath");
                StartCoroutine(EnemyDeath());
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBulletTrigger playerBulletTrigger = collision.GetComponent<PlayerBulletTrigger>();
        ChaseBulletTrigger chaseBulletTrigger = collision.GetComponent<ChaseBulletTrigger>();
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
            PlayerTrigger.Instance.CanTakeDamage(-EnemyMedium.BoddyDamage);
        }
    }
    IEnumerator EnemyDeath()
    {   
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
    }
}
