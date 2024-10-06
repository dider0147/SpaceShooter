using UnityEngine;

public class EnemyMediumMovement : MonoBehaviour
{
    private bool moveRight;
    public Enemy EnemyMedium;
    private bool canMove;
    private void OnEnable()
    {
         GetSpawnPos();
         canMove = true;
    }
    private void Update()
    {
        EnemyMediumMove();
    }
    public void GetSpawnPos()
    {
        if (transform.position.x < 0)
        {
            moveRight = true;
        }    
        else if (transform.position.x > 0)
        {
            moveRight = false;
        }    
    }
    public void EnemyMediumMove()
    {   
        if (canMove)
        {
            float moveDirection = moveRight ? 1 : -1;
            transform.position += moveDirection * EnemyMedium.Speed * Time.deltaTime * Vector3.right;
        }
        else
        {
            transform.position = transform.position;
        } 
            
        float screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        if ((transform.position.x > screenWidth && moveRight) || (transform.position.x < -screenWidth && !moveRight))
        {
            moveRight = !moveRight;
            transform.Rotate(0, 0, 180);
        }
    }
    public void StopEnemy()
    {
        canMove = false;
    }
}
