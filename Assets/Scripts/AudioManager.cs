using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public AudioSource menuMusic;
    public AudioSource battleSelectMusic;
    public AudioSource[] bgm;

    public void StopMusic()
    {
        menuMusic.Stop();
        battleSelectMusic.Stop();
        foreach (AudioSource track in bgm)
        {
            track.Stop();
        }
    }

    public void PlayMenuMusic()
    {
        StopMusic();
        menuMusic.Play();
    }

    public void PlayBattleSelectMusic()
    {
        if (!battleSelectMusic.isPlaying)
        {
            StopMusic();
            battleSelectMusic.Play();
        }
    }

    public void PlayBGM()
    {
        StopMusic();
    }
}
