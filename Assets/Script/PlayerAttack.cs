
using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform ShootPoint;
    public Transform ShootPoint2;
    public Transform ShootPoint3;
    public Transform ChasePoint;
    private float spawnTime;
    public int CountBullet = 1;
    private float chaseSpawnTime;
    public BulletType ChaseBullet;
    public BulletType DefaultBullet;
    // Update is called once per frame
    void Update()
    {   
        CountBullet = Mathf.Clamp(CountBullet, 1, 4);
        PlayerShoot();
    }
    private void PlayerShoot()
    {
        spawnTime += Time.deltaTime;
        chaseSpawnTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && spawnTime >= PlayerBulletObjectPool.instance.GetBulletType().TimeShoot)
        {   
            if (PlayerBulletObjectPool.instance.GetBulletType() == DefaultBullet)
                SoundManager.Instance.PlaySound(0);
            else
                SoundManager.Instance.PlaySound(3);
            if (CountBullet == 1 || CountBullet == 3 || CountBullet == 4)
            {
                SHoot();
                spawnTime = 0;
            }
            if (CountBullet == 2 || CountBullet == 3 || CountBullet == 4)
            {
                SHoot2();
                SHoot3();
                spawnTime = 0;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.X) && chaseSpawnTime >= ChaseBullet.TimeShoot)
        {
            SoundManager.Instance.PlaySound(0);
            ChaseShoot();
            chaseSpawnTime = 0;
        }
    }
    private void SHoot()
    {
        GameObject bullet = PlayerBulletObjectPool.instance.GetBullet();

        bullet.transform.position = ShootPoint.position;
        bullet.GetComponent<PlayerBulletMove>().SetDirection(Vector3.up);
        bullet.SetActive(true);
        
    }
    private void SHoot2()
    {
        GameObject bullet = PlayerBulletObjectPool.instance.GetBullet();

        bullet.transform.position = ShootPoint2.position;
        if (CountBullet == 2 || CountBullet == 3)
        {
            bullet.GetComponent<PlayerBulletMove>().SetDirection(Vector3.up);
        }
        else if (CountBullet == 4) 
        {
            Vector2 dir = Quaternion.Euler(0f, 0f, -15f) * Vector2.up;
            bullet.GetComponent<PlayerBulletMove>().SetDirection(dir);
            bullet.transform.rotation = Quaternion.Euler(0f, 0f, -15f);
        }
        bullet.SetActive(true);
        
    }
    private void SHoot3()
    {
        GameObject bullet = PlayerBulletObjectPool.instance.GetBullet();
        if (CountBullet == 2 || CountBullet == 3)
        {
            bullet.GetComponent<PlayerBulletMove>().SetDirection(Vector3.up);
        }
        else if (CountBullet == 4)
        {
            Vector2 dir = Quaternion.Euler(0f, 0f, 15f) * Vector2.up;
            bullet.GetComponent<PlayerBulletMove>().SetDirection(dir);
            bullet.transform.rotation = Quaternion.Euler(0f, 0f, 15f);
        }
        bullet.transform.position = ShootPoint3.position;
        bullet.SetActive(true);
        
    }
    public void UpdateBullet()
    {
        CountBullet++;
    }
    private void ChaseShoot()
    {
        GameObject bullet = ChasBulletPool.Instance.GetBullet();
        bullet.transform.position = ChasePoint.position;
        bullet.SetActive(true);
        
    }
}
