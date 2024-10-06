using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Dictionary<string, List<GameObject>> EnemyList = new();
    public static EnemyManager instance;
    public Color DefaultColor;
    public GameObject LowEnemy;
    public GameObject MediumEnemy;
    public GameObject Meoteor;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        AddObjectToList("Low", LowEnemy);
        AddObjectToList("Medium", MediumEnemy);
        AddObjectToList("Meoteor", Meoteor);
    }

    public void AddObjectToList(string name, GameObject prefab)
    {
        if (!EnemyList.ContainsKey(name))
        {
            EnemyList.Add(name, new List<GameObject>());
        }
        for (int i = 0; i < 5; i++)
        {
            GameObject enemy = Instantiate(prefab);
            enemy.SetActive(false);
            EnemyList[name].Add(enemy);
            enemy.transform.SetParent(transform);
        }
    }
    public GameObject GetEnemy(string name, GameObject prefab)
    {
        foreach (GameObject enemy in EnemyList[name])
        {
            if (!enemy.activeInHierarchy)
            {
                enemy.GetComponent<SpriteRenderer>().color = DefaultColor;
                return enemy;
            }
        }

        GameObject Newbullet = Instantiate(prefab);
        Newbullet.transform.Rotate(0, 0, 180);
        Newbullet.SetActive(false);
        EnemyList[name].Add(Newbullet);
        Newbullet.transform.SetParent(transform);
        return Newbullet;


    }
}
