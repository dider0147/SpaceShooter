using UnityEngine;

public class MeoteorMovement : MonoBehaviour
{
    public float speed;
    Rigidbody2D Rigidbody2D;
    Vector2 targetPos;
    private bool isStop = false;
    public Enemy Meoteor;
    private void OnEnable()
    {   
        Rigidbody2D = GetComponent<Rigidbody2D>();
        targetPos = new(Random.Range(-10f, 10f), -15f);
    }
    private void Update()
    {
        MeoteorFall();
    }
    private void MeoteorFall()
    {
        if (!isStop)
        {
            Vector2 getDirection = targetPos - (Vector2)transform.position;
            float angle = Mathf.Atan2(getDirection.y, getDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle + 180f);
            Rigidbody2D.velocity = getDirection.normalized * Meoteor.Speed;
            if (Vector2.Distance(transform.position, targetPos) < 0.1f)
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            Rigidbody2D.velocity = Vector2.zero;
        }
        
        
    }
    public void StopMeoteor()
    {
        isStop = true; 
    }

}
