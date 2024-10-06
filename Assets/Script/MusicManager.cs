using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource SourceClip;
    public AudioClip[] MusicClip;
    public static MusicManager Instance { get; private set; }
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
    public void PlayMusic(int IndexMusic)
    {
        SourceClip.clip = MusicClip[IndexMusic];
        SourceClip.Play();
    }
    
}
