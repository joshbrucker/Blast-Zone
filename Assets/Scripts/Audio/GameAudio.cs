using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    public AudioClip soundEffect;

    public AudioSource musicSource;

    public AudioClip LevelSong1;
    public AudioClip LevelSong2;
    public AudioClip LevelSong3;
    public AudioClip LevelSong4;
    public AudioClip LevelSong5;
    public AudioClip LevelSong6;
    public AudioClip LevelSong7;
    public AudioClip LevelSong8;
    public AudioClip LevelSong9;
    public AudioClip LevelSong10;
    

    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = soundEffect;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseAudio()
    {
        musicSource.Pause();
    }

    public void PlayAudio()
    {
        musicSource.Play();
    }

    public void PlaySongByLevel()
    {
        if(ItemManager.completions == 1)
        {
            musicSource.clip = soundEffect;
        }
    }

    
}
