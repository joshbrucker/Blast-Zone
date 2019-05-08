using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameAudio : MonoBehaviour
{


    public Slider volume;
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

    int lastLevel = ItemManager.completions;

    AudioClip[] songList = new AudioClip[100];

    private bool shouldReplay = true;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }



    // Start is called before the first frame update
    void Start()
    {
        //SetSongList();
        //musicSource.clip = soundEffect;
        //musicSource.Play();

        songList[0] = LevelSong1;
        songList[1] = LevelSong2;
        songList[2] = LevelSong3;
        songList[3] = LevelSong4;
        songList[4] = LevelSong5;
        songList[5] = LevelSong6;
        songList[6] = LevelSong7;
        songList[7] = LevelSong8;
        songList[8] = LevelSong9;
        songList[9] = LevelSong10;

    }

    // Update is called once per frame
    void Update()
    {

        /*  if(ItemManager.completions != lastLevel)
          {
              PlaySongByLevel();
          }
          lastLevel = ItemManager.completions;*/

        if (shouldReplay)
        {
            PlaySongList();
            shouldReplay = false;
        } 

        musicSource.volume = volume.value;
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
            musicSource.clip = LevelSong1;
            musicSource.Play();
        }
        else if(ItemManager.completions == 2)
        {
            musicSource.clip = LevelSong2;
            musicSource.Play();
        }
        else if (ItemManager.completions == 3)
        {
            musicSource.clip = LevelSong3;
            musicSource.Play();
        }
    }

    void SetSongList()
    {
        // songList = { LevelSong1, LevelSong2, LevelSong3, LevelSong4, LevelSong5, LevelSong6,
        //     LevelSong7, LevelSong8, LevelSong9, LevelSong10 };


    }



    void PlaySongList()
    {
        /*
          musicSource.clip = songList[i];
          musicSource.Play();
          yield return new WaitForSeconds(musicSource.clip.length)*/

        int infiniteVal = 0;

        while (infiniteVal >= 0 && infiniteVal<10)
        {
            for (int i = 0; i < songList.Length; i++)
            {
                if (songList[i] != null)
                {
                    musicSource.clip = songList[i];
                    musicSource.Play();
                    musicSource.Play();
                    new WaitForSeconds(musicSource.clip.length);
                }
            }
            infiniteVal++;
        }

        shouldReplay = true;
    }
}
