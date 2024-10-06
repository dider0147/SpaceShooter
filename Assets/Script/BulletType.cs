using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "Bullet Type")]
public class BulletType : ScriptableObject
{
    public GameObject BulletPrefab;
    public float speed;
    public int Damage;
    public float TimeShoot;
}
