
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletObjectPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> PlayerDefaultBulletList;
    [SerializeField] private List<GameObject> PlayerStrongBulletList;
    public Transform PlayerBulletPool;
    public static PlayerBulletObjectPool instance;
    public Color DefaultColor;
    public BulletType DefaultBullet;
    public BulletType StrongBullet;
    private BulletType currentBullet;
    private List<GameObject> currentBulletList;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {   
        currentBullet = DefaultBullet;
        currentBulletList = PlayerDefaultBulletList;
        AddObjectToList(PlayerDefaultBulletList, DefaultBullet);
        AddObjectToList(PlayerStrongBulletList, StrongBullet);
    }
    private void Update()
    {
        SwapBullet();
        GetBullet();
    }

    private void SwapBullet()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentBullet = DefaultBullet;
            currentBulletList = PlayerDefaultBulletList;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentBullet = StrongBullet;
            currentBulletList = PlayerStrongBulletList;
        }
    }
    public void AddObjectToList(List<GameObject> list, BulletType type)
    {
        for (int i = 0; i < 10; i++) 
        {   
            GameObject bullet = Instantiate(type.BulletPrefab);
            bullet.SetActive(false);
            list.Add(bullet);
            bullet.transform.SetParent(PlayerBulletPool);
        }
    }
    public GameObject GetBullet()
    {
        foreach (GameObject bullet in currentBulletList)
        {
            if (!bullet.activeInHierarchy)
            {   
                bullet.GetComponent<SpriteRenderer>().sprite = currentBullet.BulletPrefab.GetComponent<SpriteRenderer>().sprite;
                bullet.GetComponent<SpriteRenderer>().color = DefaultColor;
                return bullet;
            }
        }
        GameObject Newbullet = Instantiate(currentBullet.BulletPrefab);
        Newbullet.SetActive(false);
        currentBulletList.Add(Newbullet);
        Newbullet.transform.SetParent(PlayerBulletPool);
        return Newbullet;
    }
   public BulletType GetBulletType()
    {
        return currentBullet;
    }
    
}
