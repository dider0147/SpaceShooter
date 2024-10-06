using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public GameObject LowEnemy;
    public float SpawnTime_Low;
    private float spawnTime_Low = 0;
    private int countEnemy;
    private bool startLevel = false;
    private bool spawnEnd = false;
    private bool finishLevel = false;
    

    private void OnEnable()
    {
        StartCoroutine(StartLevel());
    }
    private void Update()
    {
        EnemyLowSpawn();
        CheckEndLevel();
    }
    private void EnemyLowSpawn()
    {
        if (countEnemy == 6)
        {   
            spawnEnd = true;
            return;
        }
        if (startLevel)
        {
            spawnTime_Low -= Time.deltaTime;
            if (spawnTime_Low <= 0)
            {
                countEnemy++;
                Vector2 rdPos = new(Random.Range(-8f, 8f), 6f);
                GameObject clone = EnemyManager.instance.GetEnemy("Low", LowEnemy);
                clone.transform.position = rdPos;
                clone.SetActive(true);
                spawnTime_Low = SpawnTime_Low;
            }
        }
        
    }
    IEnumerator StartLevel()
    {
        yield return new WaitForSeconds(5f);
        UIManager.Instance.DisableLevelText();
        startLevel = true;
    }
    private void CheckEndLevel()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        bool allEnemiesDeath = true;
        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeInHierarchy)
            {
                allEnemiesDeath = false;
            }
        }
        if (!finishLevel)
        {
            
            if (allEnemiesDeath && spawnEnd)
            {
                finishLevel = true;
                LevelControl.Instance.NextLevel();
            }
        }
        
    }
}
    
