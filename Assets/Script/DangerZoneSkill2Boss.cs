using System.Collections;
using UnityEngine;

public class DangerZoneSkill2Boss : MonoBehaviour
{   
    private Collider2D Collider2D;
    public EnemyWeapon Bomb;
    public Animator animator;
    private void OnEnable()
    {
        Collider2D = GetComponent<Collider2D>();
        Collider2D.enabled = false;
        StartCoroutine(DangerZoneExplose());
    }
    private IEnumerator DangerZoneExplose()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.Instance.PlaySound(7);
        animator.Play("Skill2Explosion");
        Collider2D.enabled = true;
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerTrigger.Instance.CanTakeDamage(-Bomb.Damage);
        }    
    }
}
