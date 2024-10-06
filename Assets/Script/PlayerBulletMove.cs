using UnityEngine;

public class PlayerBulletMove : MonoBehaviour
{
    //public float speed;
    public Rigidbody2D Rigidbody2D;
    private bool isStop;
    public BulletType type;
    Vector3 direction;
    private void Update()
    {
        BulletMove();
    }
    private void BulletMove()
    {   
        if (!isStop)
            Rigidbody2D.velocity = direction * type.speed;
        else
            Rigidbody2D.velocity = Vector2.zero;
    }
    public void StopBullet()
    {
        isStop = true;
    }
    private void OnDisable()
    {
        isStop = false;
        transform.rotation = Quaternion.identity;
    }
    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }
}
