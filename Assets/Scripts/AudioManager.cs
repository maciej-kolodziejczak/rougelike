using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource levelMusic, gameOverMusic, winMusic;
    [SerializeField] private AudioSource[] sfx;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayGameOver()
    {
        levelMusic.Stop();
        gameOverMusic.Play();
    }

    public void PlayLevelWin()
    {
        levelMusic.Stop();
        winMusic.Play();
    }

    public void PlaySfx(int index)
    {
        sfx[index].Stop();
        sfx[index].Play();
    }
}
