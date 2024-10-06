using UnityEngine;

public class BombTrigger : MonoBehaviour
{   
    public BombMovement BombMovement;
    public Animator Animator;
    public EnemyWeapon Bomb;
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.CompareTag("Player"))
        {
            SoundManager.Instance.PlaySound(7);
            BombMovement.BombExplosion();
            Animator.SetTrigger("Explosion");
            PlayerTrigger.Instance.CanTakeDamage(-Bomb.Damage);
        }    
    }
}
