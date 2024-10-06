using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider MusicSlider;
    public Slider SoundSlider;
    public static VolumeControl Instance;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        MusicSlider.value = VolumeValueControl.Instance.VolumeValue;
        SoundSlider.value = VolumeValueControl.Instance.SoundVolumeValue;

        MusicSlider.onValueChanged.AddListener(VolumeValueControl.Instance.SetMusicVolume);
        SoundSlider.onValueChanged.AddListener(VolumeValueControl.Instance.SetSoundVolume);
    }
    public void SaveAudioVolume()
    {
        PlayerPrefs.SetFloat("MusicVolume", MusicSlider.value);
        VolumeValueControl.Instance.VolumeValue = MusicSlider.value;
        PlayerPrefs.SetFloat("SoundVolume", SoundSlider.value);
        VolumeValueControl.Instance.SoundVolumeValue = SoundSlider.value;
        PlayerPrefs.Save();
        StartScenceManager.Instance.TurnoffSetting();
    }
    public void SaveAudioVolumeInGame()
    {
        PlayerPrefs.SetFloat("MusicVolume", MusicSlider.value);
        VolumeValueControl.Instance.VolumeValue = MusicSlider.value;
        PlayerPrefs.SetFloat("SoundVolume", SoundSlider.value);
        VolumeValueControl.Instance.SoundVolumeValue = SoundSlider.value;
        PlayerPrefs.Save();
        GameManager.Instance.BackPause();
    }
}

