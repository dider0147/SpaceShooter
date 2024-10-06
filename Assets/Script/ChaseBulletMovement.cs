using UnityEngine;

public class ChaseBulletMovement : MonoBehaviour
{
    Rigidbody2D Rigidbody2D;
    private Transform target;
    public BulletType type;
    private bool isStop = false;
    private void OnEnable()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        target = FindFarestEnemy();
    }
    private void Update()
    {
        ChaseBulletMove();
    }
    private void ChaseBulletMove()
    {   
        if (!isStop)
        {
            if (target != null)
            {
                Vector2 direction = target.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.SetPositionAndRotation(Vector2.MoveTowards(transform.position, target.position, type.speed * Time.deltaTime), Quaternion.Euler(0, 0, angle + 180));
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
                Rigidbody2D.velocity = Vector2.up * type.speed;
            }
        }
        else
        {
            Rigidbody2D.velocity = Vector2.zero;
        }
        
    }
    private Transform FindFarestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Transform farestEnemy = null;
        float farestDistance = 0f;
        //Vector2 playerPos = transform.position;
        foreach (GameObject enemy in enemies)
        {   
            if (enemy != null)
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (distance > farestDistance)
                {
                    farestDistance = distance;
                    farestEnemy = enemy.transform;
                }
            }
            
        }
        return farestEnemy;
    }
    public void StopBullet()
    {
        isStop = true;
    }
    public void ResetBullet()
        { isStop = false; }
}
