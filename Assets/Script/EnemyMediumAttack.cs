using UnityEngine;

public class EnemyMediumAttack : MonoBehaviour
{
    public float SpawnTIme;
    private float spawnTime;
    public GameObject Bomb;
    // Update is called once per frame
    void Update()
    {
        EnemyAttack();
    }
    private void EnemyAttack()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime >= SpawnTIme )
        {
            GameObject bomb = EnemyBulletPool.instance.GetBullet("BulletMedium", Bomb);
            SoundManager.Instance.PlaySound(3);
            bomb.SetActive( true );
            bomb.transform.position = transform.position;
            spawnTime = 0;
        }
    }
}
