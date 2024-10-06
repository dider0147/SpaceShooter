using System.Collections;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public Color DefaultColor;
    public Color InvisibleColor;
    public SpriteRenderer SpriteRenderer;
    private bool canBeAttacked = true;
    public Animator animator;
    
    public int hp = 100;
    private bool playerDeath = false;
    public static PlayerTrigger Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    private void OnEnable()
    {
        transform.position = new Vector3(0, -7, 0);
        StartCoroutine(InvisibleMan());
    }
    private void OnDisable()
    {
        hp = 100;
    }
    private void Update()
    {
        hp = Mathf.Clamp(hp, 0, 100);
        UIManager.Instance.UpdateHP(hp);
        UIManager.Instance.HPColor(hp);
        if (hp == 0)
        {   
            if (!playerDeath) 
                StartCoroutine(RebornPlayer());
        }
    }
    
    private IEnumerator PlayerBeAttacked()
    {
        
        yield return new WaitForSeconds(1f);
        SpriteRenderer.color = DefaultColor;
        canBeAttacked = true;
    }
    public void CanTakeDamage(int damage)
    {
        if (canBeAttacked)
        {
            canBeAttacked = false;
            CameraShake cameraShake = Camera.main.GetComponent<CameraShake>();
            cameraShake.TimeShakeDuration(0.2f);
            SpriteRenderer.color = InvisibleColor;
            hp += damage;
            StartCoroutine(PlayerBeAttacked());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BulletBuff"))
        {
            SoundManager.Instance.PlaySound(4);
            gameObject.GetComponent<PlayerAttack>().UpdateBullet();
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("RecoverHeal"))
        {
            SoundManager.Instance.PlaySound(5);
            hp += 20;
            Destroy(collision.gameObject);
        }
    }
    IEnumerator RebornPlayer()
    {
        playerDeath = true;
        SoundManager.Instance.PlaySound(6);
        animator.Play("PlayerDeath");
        GameManager.Instance.PlayerDeath();
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
        gameObject.SetActive(true);
        playerDeath = false;
    }
    IEnumerator InvisibleMan()
    {
        canBeAttacked = false;
        yield return new WaitForSeconds(3f);
        canBeAttacked = true;
        SpriteRenderer.color = DefaultColor;
    }

}
