
using System.Collections;
using UnityEngine;

public class EnemyBulleMove : MonoBehaviour
{
    public EnemyWeapon Bullet;
    public Rigidbody2D Rigidbody2D;
    private bool isStop;
    private GameObject Player;
    Vector2 playerPos;
    Vector2 targetPos;
    private void OnEnable()
    {
        Player = GameObject.FindWithTag("Player");
        StartCoroutine(TimeDisapear());
        GetDirection();
    }
    private void Update()
    {
        BulletMove();
    }

    private void BulletMove()
    {
        if (!isStop)
        {
            if (Player != null)
            {
                
                Rigidbody2D.velocity = targetPos.normalized * Bullet.speed;
            }

        }
        else
            Rigidbody2D.velocity = Vector2.zero;
    }
    public void StopBullet()
    {
        isStop = true;
    }
    private void GetDirection()
    {   if (Player != null)
        {

            playerPos = Player.transform.position;
            targetPos = playerPos - (Vector2)transform.position;
            float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
    }
    public void ResetBullet()
    {
        isStop = false;
    }
    private IEnumerator TimeDisapear()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
    
}
