using System.Collections;
using UnityEngine;

public class EnemyBulletTrigger : MonoBehaviour
{
    public Animator animator;
    public EnemyBulleMove EnemyBulleMove;
    public EnemyWeapon Bullet;
    private void OnEnable()
    {
        EnemyBulleMove = GetComponent<EnemyBulleMove>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.Instance.PlaySound(7);
            PlayerTrigger.Instance.CanTakeDamage(-Bullet.Damage);
            EnemyBulleMove.StopBullet();
            animator.SetTrigger("EnemyAim");
            StartCoroutine(TimeDisapear());
        }
    }
    IEnumerator TimeDisapear()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    }
}
