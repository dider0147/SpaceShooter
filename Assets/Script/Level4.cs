using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4 : MonoBehaviour
{
    public GameObject FinalBoss;
    public bool start = false;
    private bool bossApear= false;
    private bool finishLevel = false;
    public static Level4 Instance {  get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    private void OnEnable()
    {
        MusicManager.Instance.PlayMusic(4);
        StartCoroutine(LevelStart());
    }
    private void Update()
    {
        CheckLevelEnd();
    }
    private IEnumerator LevelStart()
    {
        yield return new WaitForSeconds(5f);
        UIManager.Instance.UseFlashEffect(1, 3);
        FinalBoss.SetActive(true);
        yield return null;
        SoundManager.Instance.PlaySound(2);
        yield return new WaitForSeconds(5f);
        MusicManager.Instance.PlayMusic(2);
        start = true;
        bossApear = true;
    }
    private void CheckLevelEnd()
    {
        GameObject boss = GameObject.FindGameObjectWithTag("Enemy");
        bool bossDeath = false;
        if (boss == null) 
            bossDeath = true;
        if (!finishLevel)
        {   
            if (bossDeath && bossApear)
            {
                finishLevel = true;
                LevelControl.Instance.NextLevel();
            }
        }
    }
}
