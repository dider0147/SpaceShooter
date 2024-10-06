using System.Collections;
using UnityEngine;

public class MeoteorTrigger : MonoBehaviour
{   
    public Animator animator;
    public GameObject MeoteorFlame;
    private bool isExplose = false;
    public MeoteorMovement MeoteorMovement;
    public Enemy Meoteor;
    private int currentHP;

    private void OnEnable()
    {
        MeoteorMovement = GetComponent<MeoteorMovement>();
    }
    private void Start()
    {
        currentHP = Meoteor.HP;
    }
    private void OnDisable()
    {
        isExplose = false;
        currentHP = Meoteor.HP;
    }
    private void Update()
    {   
        currentHP = Mathf.Clamp(currentHP, 0, Meoteor.HP);
        if (!isExplose)
        {
            if (currentHP == 0)
            {
                isExplose = true;
                SoundManager.Instance.PlaySound(7);
                GameManager.Instance.UpdateScore(Meoteor.Score);
                MeoteorMovement.StopMeoteor();
                animator.Play("MeoteorExplose");
                StartCoroutine(MeoteorDeath());
                
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
            PlayerTrigger.Instance.CanTakeDamage(-Meoteor.BoddyDamage);
        }
        
    }
    private IEnumerator MeoteorDeath()
    {   
        MeoteorFlame.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        gameObject.SetActive(false);
    }
}
