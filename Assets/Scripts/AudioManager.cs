using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource[] sfx;
    public AudioSource[] bgm;
    void Awake()
    {
        instance = this;

    }
    private void Start()
    {
        PlayBGM(0);
    }
    public void PlaySFX(int i)
    {
        if(i < sfx.Length)
        {
            sfx[i].Play();
        }
    }
    public void PlayBGM(int i)
    {      
        if(i < bgm.Length)
        {
            StopAllBGM();
            bgm[i].Play();
        }
    }
    public void StopAllBGM()
    {
        for(int i=0; i < bgm.Length; i++)
        {
            bgm[i].Stop();
        }
    }
}
