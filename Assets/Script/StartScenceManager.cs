using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScenceManager : MonoBehaviour
{   
    private bool TutorialOn;
    private bool SettingOn;
    public GameObject TutorialPanel;
    public GameObject SettingPanel;
    public static StartScenceManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {   
        TutorialOn = false;
        SettingOn = false;
        MusicManager.Instance.PlayMusic(1);
    }
    private void Update()
    {
        TurOffFunction();
        TutorialPanel.SetActive(TutorialOn);
        SettingPanel.SetActive(SettingOn);
    }
    public void LoadGamePlay()
    {
        SceneManager.LoadScene("GamePlayScence");
    }
    public void TurnOnTutorial()
    {
        TutorialOn = true;
    }
    public void TurnOnSetting()
    {
        SettingOn = true;
    }
    private void TurOffFunction()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TutorialOn = false;
            SettingOn = false;
            VolumeValueControl.Instance.MusicSource.volume = VolumeValueControl.Instance.VolumeValue;
            VolumeControl.Instance.MusicSlider.value = VolumeValueControl.Instance.VolumeValue;
            VolumeValueControl.Instance.SoundSource.volume = VolumeValueControl.Instance.SoundVolumeValue;
            VolumeControl.Instance.SoundSlider.value = VolumeValueControl.Instance.SoundVolumeValue;
        }
    }
    public void Quit()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    public void TurnoffSetting()
    {
        SettingOn = false;
    }
}
