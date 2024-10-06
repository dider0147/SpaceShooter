using System.Collections;
using UnityEngine;

public class BombMovement : MonoBehaviour
{
    private bool explosion = false;
    public Rigidbody2D Rigidbody2D;
    public EnemyWeapon Bomb;
    private void OnEnable()
    {
        StartCoroutine(TimeDisapear());
    }
    // Update is called once per frame
    void Update()
    {
        BombMove();
    }
    private void BombMove()
    {
        if (!explosion)
        {
            Rigidbody2D.velocity = Vector2.down * Bomb.speed;
        }    
        else if (explosion)
        {
            Rigidbody2D.velocity= Vector2.zero;
        }
    }
    public void BombExplosion()
    {
        explosion = true;
    }
    public void ResetBomb()
    {
        explosion = false;
    }
    private IEnumerator TimeDisapear()
    {
        yield return new WaitForSeconds(4f);
        gameObject.SetActive(false);
    }
}
