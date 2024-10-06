using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Life;
    private int currentLife;
    public int Score {  get; private set; }
    private int bestScore;
    public static GameManager Instance { get; private set; }
    private bool pause;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        currentLife = Life.Count;
        UIManager.Instance.ScorePlayer(Score);
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        MusicManager.Instance.PlayMusic(0);
        pause = false;
    }
    private void Update()
    {
        UIManager.Instance.ScorePlayer(Score);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePause();
        }
        CheckPause();
        if (currentLife == 0)
        {
            CheckBestScore();
            Time.timeScale = 0;
            UIManager.Instance.GameOver(Score, bestScore);
        }
    }
    public void PlayerDeath()
    {
        if (currentLife > 0)
        {
            currentLife--;
            Debug.Log(currentLife);
            Life[currentLife].SetActive(false); 
        }
    }
    public void UpdateScore(int bonus)
    {
        Score += bonus;
    }
    public void CheckBestScore()
    {
        if (Score > bestScore)
        {
            bestScore = Score;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
        }
    }
    public void LoadGamePlayeScence()
    {
        SceneManager.LoadScene("GamePlayScence");
        
    }
    public void GamePause()
    {   
        pause = !pause;
        UIManager.Instance.PauseGame(pause);
        UIManager.Instance.Setting(false);

    }
    private void CheckPause()
    {
        if (pause)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    public void SettingGame()
    {
        UIManager.Instance.PauseGame(false);
        UIManager.Instance.Setting(true);
    }
    public void BackPause()
    {
        UIManager.Instance.PauseGame(true);
        UIManager.Instance.Setting(false);
    }
    public void LoadMenuScence()
    {
        SceneManager.LoadScene("StartScence");
    }
    public int GetBestScore()
    {
        return bestScore;
    }
}
