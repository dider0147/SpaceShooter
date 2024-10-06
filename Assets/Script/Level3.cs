using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour
{
    public GameObject Meoteor;
    private bool spawnEnd;
    private bool finishLevel = false;
    private void OnEnable()
    {
        StartCoroutine(SpawnMeoteor());
    }
    private void Update()
    {
        CheckEndLevel();
    }
    private IEnumerator SpawnMeoteor()
    {
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < 20; i++)
        {
            Vector2 spawnPos = new(Random.Range(-12f, 12f), 7);
            GameObject meoteor = Instantiate(EnemyManager.instance.GetEnemy("Meoteor", Meoteor), spawnPos, Quaternion.identity);
            CameraShake cameraShake = Camera.main.GetComponent<CameraShake>();
            cameraShake.TimeShakeDuration(0.5f);
            meoteor.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
        spawnEnd = true;
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
