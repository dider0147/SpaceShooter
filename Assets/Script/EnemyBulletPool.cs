
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPool : MonoBehaviour
{

    [SerializeField] private Dictionary<string, List<GameObject>> EnemyBulletList = new();
    public static EnemyBulletPool instance;
    public Color DefaultColor;
    public EnemyWeapon BulletLow;
    public EnemyWeapon BombMedium;
    public EnemyWeapon Skill3Boss;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        AddObjectToList("BulletLow", BulletLow.EnemyWeaponPrefab);
        AddObjectToList("BulletMedium", BombMedium.EnemyWeaponPrefab);
        AddObjectToList("BulletBoss", Skill3Boss.EnemyWeaponPrefab);
    }

    public void AddObjectToList(string name, GameObject prefab)
    {   
        if ( !EnemyBulletList.ContainsKey(name))
        {
            EnemyBulletList.Add(name, new List<GameObject>());
        }
        for (int i = 0; i < 15; i++)
        {
            GameObject bullet = Instantiate(prefab);
            bullet.transform.Rotate(0, 0, 180);
            bullet.SetActive(false);
            EnemyBulletList[name].Add(bullet);
            bullet.transform.SetParent(transform);
        }
    }
    public GameObject GetBullet(string name, GameObject prefab)
    {
        foreach (GameObject bullet in EnemyBulletList[name])
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.GetComponent<SpriteRenderer>().color = DefaultColor;
                if (name == "BulletLow")
                {
                    bullet.GetComponent<EnemyBulleMove>().ResetBullet();
                }
                else if (name == "BulletMedium")
                {
                    bullet.GetComponent<BombMovement>().ResetBomb();
                }

                return bullet;
            }
        }
        
            GameObject Newbullet = Instantiate(prefab);
            Newbullet.transform.Rotate(0, 0, 180);
            Newbullet.SetActive(false);
            EnemyBulletList[name].Add(Newbullet);
            Newbullet.transform.SetParent(transform);
            return Newbullet;
        
        
    }
 
}
