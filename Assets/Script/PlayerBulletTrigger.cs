using System.Collections;
using UnityEngine;

public class PlayerBulletTrigger : MonoBehaviour
{
    public Animator animator;
    private PlayerBulletMove PlayerBulletMove;
    public BulletType BulletType;
    private void Start()
    {
        PlayerBulletMove = GetComponent<PlayerBulletMove>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {   if (collision.CompareTag("Enemy"))
        {
            SoundManager.Instance.PlaySound(7);
            PlayerBulletMove.StopBullet();
            animator.SetTrigger("Aim");
            StartCoroutine(ResetBullet());
        }
        else if (collision.CompareTag("ResetBulletZone"))
        {
            StartCoroutine(ResetBullet());
        }
    }
    public void GetDamage(ref int currentHP)
    {
        currentHP -= BulletType.Damage;
    }
    
    private IEnumerator ResetBullet()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }
}

