using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image FlashImage;
    public RectTransform hpRectTransform;
    public Image hpImage;
    public TextMeshProUGUI ScoreBoard;
    public TextMeshProUGUI LevelText;
    public GameObject PausePanel;
    public GameObject SettingPanel;
    public GameObject GameOverPanel;
    public GameObject VictoryPanel;
    public TextMeshProUGUI GameOverScoreText;
    public TextMeshProUGUI VictoryScoreText;
    public TextMeshProUGUI GameOverBestScoreText;
    public TextMeshProUGUI VictoryBestScoreText;
    public static UIManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    public void UseFlashEffect(float flashDuration, float fadeDuration)
    {
        StartCoroutine(FlashAppear(flashDuration, fadeDuration));
    }
    private IEnumerator FlashAppear(float flashDuration, float fadeDuration)
    {
        FlashImage.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(flashDuration);
        float fadeTime = 0f;
        while (fadeTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1, 0, fadeTime / fadeDuration);
            FlashImage.color = new Color(1,1,1,alpha);
            fadeTime += Time.deltaTime;
            yield return null;
        }
        FlashImage.color = new Color(1, 1, 1, 0);

    }
    public void UpdateHP(int HP)
    {
        hpRectTransform.sizeDelta = new Vector2(HP, hpRectTransform.sizeDelta.y);

    }
    public void HPColor(int HP)
    {
        if (HP >= 70)
            hpImage.color = Color.green;
        else if (HP >= 30)
            hpImage.color = Color.yellow;
        else
            hpImage.color = Color.red;
    }
    public void ScorePlayer(int score)
    {
        ScoreBoard.text = "Score: " + score;
    }
    public void LevelScence(int level)
    {
        LevelText.text = "Level " + level;
        LevelText.gameObject.SetActive(true);
        
    }
    public void DisableLevelText()
    {
        LevelText.gameObject.SetActive(false);
    }
    public void PauseGame(bool pause)
    {
        PausePanel.SetActive(pause);
    }
    public void Setting(bool setting)
    {
        SettingPanel.SetActive(setting);
    }
    public void GameOver(int score, int bestScore)
    {
        GameOverPanel.SetActive(true);
        GameOverScoreText.text = "Score: " + score;
        GameOverBestScoreText.text = "Best Score; " + bestScore; 
    }
    public void Victory(int score, int bestScore)
    {
        VictoryPanel.SetActive(true);
        VictoryScoreText.text = "Score: " + score;
        VictoryBestScoreText.text = "Best Score; " + bestScore;
    }
}
