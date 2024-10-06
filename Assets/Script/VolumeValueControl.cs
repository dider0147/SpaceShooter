using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValueControl : MonoBehaviour
{
    public AudioSource MusicSource;
    public AudioSource SoundSource;
    public static VolumeValueControl Instance { get; private set; }
    public float VolumeValue;
    public float SoundVolumeValue;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        VolumeValue = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        MusicSource.volume = VolumeValue;
        SoundVolumeValue = PlayerPrefs.GetFloat("SoundVolume", 0.5f);
        SoundSource.volume = SoundVolumeValue;
    }
    public void SetMusicVolume(float volume)
    {
        MusicSource.volume = volume;
    }
    public void SetSoundVolume(float volume)
    {
        SoundSource.volume = volume;
    }
}
