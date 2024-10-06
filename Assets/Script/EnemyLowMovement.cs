using System.Collections;
using UnityEngine;

public class EnemyLowMovement : MonoBehaviour
{

    public Enemy EnemyLow;
    public Rigidbody2D Rigidbody2D;
    Vector2 targetStartPos;
    private bool start = true;
    Vector2 currentTargetPos;
    private bool canMove = false;
    private GameObject player;
    public EnemyLowTrigger trigger;
    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player");
        GetStart();
    }
    private void OnDisable()
    {
        start = true;
    }
    private void Update()
    {
        EnemyMove();

    }
    private void GetStart()
    {
        targetStartPos = (Vector2)transform.position + Vector2.down * 4;
    }
    private void EnemyMove()
    {
        if (start)
        {
            StartCoroutine(StartMove()); 
        }
        else
        {
            Vector2 targetPos = player.transform.position - transform.position;
            float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
            transform.SetPositionAndRotation(Vector2.MoveTowards(transform.position, currentTargetPos, EnemyLow.Speed * Time.deltaTime), Quaternion.Euler(0, 0, angle - 90));
        }
    }
    public bool Start
    {
        get { return start; }
    }
    private IEnumerator RealEnemy()
    {   
        while (canMove)
        {
            currentTargetPos = GetRandomPos();
            while (Vector2.Distance(transform.position, currentTargetPos) > 0.1f)
            {
                yield return null;
            }
            yield return new WaitForSeconds(3f);
        }
    }
    private Vector2 GetRandomPos()
    {
        float posX = Random.Range(-8f, 8f);
        float posY = Random.Range(0f, 4f);
        return new(posX, posY);
    }
    private IEnumerator StartMove()
    {
        transform.SetPositionAndRotation(Vector2.MoveTowards(transform.position, targetStartPos, EnemyLow.Speed * Time.deltaTime), Quaternion.Euler(0, 0, 180));
        yield return new WaitForSeconds(1f);
        if (Vector2.Distance(transform.position, targetStartPos) < 0.15f)
        {
            trigger.canAttack = true;
            start = false;
            canMove = true;
            StartCoroutine(RealEnemy());
        }
    }
}
