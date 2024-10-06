using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;
    public Rigidbody2D Rigidbody2D;
    public float speed;
    Vector2 camLeftBot;
    Vector2 camRightTop;
    private bool start = true;
    Vector2 targetPos;
    private void Start()
    {
        CameraControl();
    }
    private void OnEnable()
    {
        GetStart();
    }
    private void OnDisable()
    {
        start = true;
    }
    // Update is called once per frame  
    void Update()
    {
        GetDirection();
    }
    private void FixedUpdate()
    {
        PlayerMove();
    }
    private void GetStart()
    {
        targetPos = (Vector2)transform.position + Vector2.up * 4;
    }
    private void PlayerMove()
    {   
        if (start)
        {
            StartCoroutine(StartMove());
        }
        else
        {
            Rigidbody2D.MovePosition(Rigidbody2D.position + speed * Time.fixedDeltaTime * movement);
            float posX = Mathf.Clamp(transform.position.x, camLeftBot.x, camRightTop.x);
            float posY = Mathf.Clamp(transform.position.y, camLeftBot.y, camRightTop.y);
            transform.position = new Vector2(posX, posY);
        }
    }
    IEnumerator StartMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);
        yield return new WaitForSeconds(0.5f);
        start = false ;
    }
    private void GetDirection()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        
    }
    private void CameraControl()
    {
        camLeftBot = Camera.main.ViewportToWorldPoint(new Vector2(0.05f, 0.1f));

        camRightTop = Camera.main.ViewportToWorldPoint(new Vector2(0.95f, 0.9f));
    }
    
}
