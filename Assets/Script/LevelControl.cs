using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    public GameObject[] Levels;
    private int currentLevel = 0;
    public static LevelControl Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        ShowLevel(currentLevel);
    }
    private void ShowLevel(int level)
    {
        for (int i = 0; i < Levels.Length; i++)
        {
            Levels[i].SetActive(i == currentLevel);
        }
    }
    
    public void NextLevel()
    {   
        currentLevel++;
        if (currentLevel < Levels.Length)
        {
            StartCoroutine(DelayNextLevel(currentLevel));

        }
        else
        {
            GameManager.Instance.CheckBestScore();
            Time.timeScale = 0;
            UIManager.Instance.Victory(GameManager.Instance.Score, GameManager.Instance.GetBestScore());
        }
    }
    IEnumerator DelayNextLevel(int level)
    {   
        UIManager.Instance.LevelScence(level + 1);
        yield return new WaitForSeconds(5f);
        UIManager.Instance.DisableLevelText();
        ShowLevel(level);
    }
    
}
