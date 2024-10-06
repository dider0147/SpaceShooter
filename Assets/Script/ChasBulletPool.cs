using System.Collections.Generic;
using UnityEngine;

public class ChasBulletPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> chaseBulletPool;
    public BulletType ChaseBullet;
    public Transform ChaseBulletOP;
    public Color DefaultColor;
    public static ChasBulletPool Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        AddToList();
    }
    private void AddToList()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject bullet = Instantiate(ChaseBullet.BulletPrefab);
            bullet.SetActive(false);
            chaseBulletPool.Add(bullet);
            bullet.transform.SetParent(ChaseBulletOP);
        }
    }
    public GameObject GetBullet()
    {
        foreach (GameObject bullet in chaseBulletPool)
        {
            if (!bullet.activeInHierarchy)
            {   
                bullet.GetComponent<SpriteRenderer>().color = DefaultColor; 
                bullet.GetComponent<ChaseBulletMovement>().ResetBullet();
                return bullet;
            }
        }
        GameObject newBullet = Instantiate(ChaseBullet.BulletPrefab);
        newBullet.SetActive(false);
        chaseBulletPool.Add(newBullet);
        newBullet.transform.SetParent(ChaseBulletOP);
        return newBullet;
    }
}
