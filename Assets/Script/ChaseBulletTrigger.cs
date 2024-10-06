using System.Collections;
using UnityEngine;

public class ChaseBulletTrigger : MonoBehaviour
{
    public Animator animator;
    private ChaseBulletMovement ChaseBulletMovement;
    public BulletType BulletType;
    private void Start()
    {
        ChaseBulletMovement = GetComponent<ChaseBulletMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {   
            SoundManager.Instance.PlaySound(7);
            ChaseBulletMovement.StopBullet();
            animator.SetTrigger("Hit");
            StartCoroutine(ResetBullet());
        }
        else if (collision.CompareTag("ResetBulletZone"))
        {
            gameObject.SetActive(false);
        }
    }
    public void GetDamage(ref int currentHP)
    {
        currentHP -= BulletType.Damage;
    }
    private IEnumerator ResetBullet()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false );
    }
}
