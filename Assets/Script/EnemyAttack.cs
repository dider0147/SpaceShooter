using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float SpawnTime = 1f;
    private float spawnTime = 1f;
    public EnemyLowMovement EnemyLowMovement;
    public GameObject LowBullet;
    private void Update()
    {
        if (EnemyLowMovement.Start)
            return;
        EnemyShoot();
    }
    private void EnemyShoot()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime >= SpawnTime)
        {
            GameObject bullet = EnemyBulletPool.instance.GetBullet("BulletLow", LowBullet);
            SoundManager.Instance.PlaySound(3);
            bullet.transform.position = transform.position;
            bullet.SetActive(true);
            spawnTime = 0f;
        }
    }
    
}
