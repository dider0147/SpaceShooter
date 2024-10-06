using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    public GameObject EnemyMedium;
    public float SpawnTime_Medium;
    private float spawnTime_Medium = 0;
    private int countEnemy;
    private bool startLevel = false;
    private bool spawnEnd = false;
    private bool finishLevel = false;

    private void OnEnable()
    {   
        StartCoroutine(LevelStart());
    }
    private void Update()
    {
        EnemyMediumSpawn();
        LevelFinish();
    }
    private void EnemyMediumSpawn()
    {
        if (countEnemy == 6)
        {   
            spawnEnd = true;
            return;
        }
        if (startLevel)
        {
            spawnTime_Medium -= Time.deltaTime;
            if (spawnTime_Medium <= 0)
            {
                int spawn_Medium = Random.Range(1, 3);
                if (spawn_Medium == 1)
                {
                    countEnemy++;
                    Vector2 rdLeftPos = new(-10f, Random.Range(0f, 3f));
                    GameObject Clone = EnemyManager.instance.GetEnemy("Medium", EnemyMedium);
                    Clone.transform.SetPositionAndRotation(rdLeftPos, Quaternion.Euler(0, 0, -90));
                    Clone.SetActive(true);
                    spawnTime_Medium = SpawnTime_Medium;
                }
                else if (spawn_Medium == 2)
                {
                    countEnemy++;
                    Vector2 rdRightPos = new(10f, Random.Range(0f, 3f));
                    GameObject Clone = EnemyManager.instance.GetEnemy("Medium", EnemyMedium);
                    Clone.transform.SetPositionAndRotation(rdRightPos, Quaternion.Euler(0, 0, 90));
                    Clone.SetActive(true);
                    spawnTime_Medium = SpawnTime_Medium;
                }
            }
        }
        
    }
    private void LevelFinish()
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
    IEnumerator LevelStart()
    {
        yield return new WaitForSeconds(5f);
        startLevel = true;

    }
}
