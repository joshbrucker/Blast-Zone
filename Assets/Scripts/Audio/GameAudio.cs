using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    public AudioClip soundEffect;

    public AudioSource musicSource;

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
}
