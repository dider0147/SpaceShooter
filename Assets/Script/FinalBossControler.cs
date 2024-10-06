using System.Collections;
using UnityEngine;

public class FinalBossControler : MonoBehaviour
{
    public float TimeBetweenAttacks = 3;
    private float attackTime;
    public Transform Player;
    private bool isCharging = false;
    public float speed = 8;
    private bool canUseSkill = false;
    private int lastSkill = 0;
    private bool skill2Active = false;
    private bool skill3Active = false;
    public EnemyWeapon Skill2Boss;
    private bool isUsingSkill = false;
    public float[] Angles = new float[] { -45f, -22.5f, 0f, 22.5f, 45f };
    public EnemyWeapon Skill3Boss;
    public bool Death = false;
    public Enemy FinalBoss;
    public GameObject BulletBoss;

    private void Update()
    {   
        if (Death)
        {
            transform.position = transform.position;
            return;
        }
        if (Level4.Instance.start)
        {
            if (!isUsingSkill)
            {
                Attack();
            }
        }
    }

    private void Attack()
    {
        attackTime += Time.deltaTime;
        if (attackTime >= TimeBetweenAttacks)
        {
            if (!canUseSkill )
            {
                canUseSkill = true;
            }
            else if (canUseSkill)
            {
                ActRandomSkill();
                canUseSkill = false;
                attackTime = 0;
            }
        }
    }
    private void ActRandomSkill()
    {
        int rdSkill = Random.Range(1, 4);
        if (rdSkill == lastSkill)
        {
            ActRandomSkill();
        }
        else 
        {   
            lastSkill = rdSkill;
            switch (rdSkill)
            {
                case 1:
                    if (!isCharging)
                    {
                        isCharging = true;
                        StartCoroutine(Skill1());
                        isCharging = false;
                    }

                    break;
                case 2:
                    if (!skill2Active)
                    {   
                        skill2Active = true;
                        StartCoroutine(Skill2());
                        skill2Active = false;
                    }    
                    break;
                case 3:
                    if (!skill3Active)
                    {
                        skill3Active = true;
                        StartCoroutine(Skill3());
                        skill3Active = false;
                    }
                    break;
            }
        }
    }
    private IEnumerator Skill1()
    {
        float retreatDistance = 2f;
        float stopDistance = 6f;
        float chargeDistance = 8f;
        float chargerSpeed = 20f;
        isUsingSkill = true;
        Vector2 forwardPlayefPos = Player.position + Player.up * stopDistance;
        while (Vector2.Distance(transform.position, forwardPlayefPos) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, forwardPlayefPos, speed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(1.5f);
        Vector2 retreatPos = transform.position + Vector3.up * retreatDistance;
        while (Vector2.Distance(transform.position, retreatPos) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, retreatPos, speed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(1.5f);
        Vector2 charging = transform.position + Vector3.down * chargeDistance;
        while (Vector2.Distance(transform.position, charging) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, charging, chargerSpeed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(1.5f);
        Vector2 backPos = transform.position + Vector3.up * stopDistance;
        while (Vector2.Distance(transform.position,backPos) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, backPos, speed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(1.5f);
        isUsingSkill = false;
    }
    private IEnumerator Skill2()
    {   
        isUsingSkill = true;
        Vector2 defaultPos = new(0, 2);
        while (Vector2.Distance(transform.position, defaultPos) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position,defaultPos, speed * Time.deltaTime); 
            yield return null;
        }
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < 5; i++)
        {
            Vector2 rdPos = new(Random.Range(-7.3f, 7.3f), Random.Range(-3.4f, 3.4f));
            Instantiate(Skill2Boss.EnemyWeaponPrefab,rdPos, Quaternion.identity);
            yield return null;
        }
        yield return new WaitForSeconds(3f);
        isUsingSkill = false;
    }
    private IEnumerator Skill3()
    {
        isUsingSkill = true;
        Vector2 startPos = new(0, 6);
        while (Vector2.Distance(transform.position,startPos) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos, FinalBoss.Speed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(1.5f);
        BulletBoss.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        BulletBoss.SetActive(false);
        for (int i = 0;i < 3;i++)
        {
            SoundManager.Instance.PlaySound(9);
            foreach (float angle in Angles)
            {
                Shoot(angle);
                yield return null;
            }
            yield return null;
            yield return new WaitForSeconds(0.5f);
        } 
        yield return new WaitForSeconds(3f);
        isUsingSkill = false;
    }
    private void Shoot(float angle)
    {
        GameObject bullet = EnemyBulletPool.instance.GetBullet("BulletBoss", Skill3Boss.EnemyWeaponPrefab);
        bullet.transform.position = Skill3Boss.EnemyWeaponPrefab.transform.position;
        bullet.SetActive(true);
        Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.down;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * Skill3Boss.speed;
        StartCoroutine(Skill3CD(bullet));
    }
    private IEnumerator Skill3CD(GameObject bullet)
    {
        yield return new WaitForSeconds(2f);
        bullet.SetActive(false);
    }    
    public void StopBoss()
    {
        Death = true;
    }
}
