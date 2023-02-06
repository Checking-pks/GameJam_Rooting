using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : Singleton<BGMManager>
{
    [SerializeField]
    AudioClip defaultAudio;
    [SerializeField]
    AudioClip endingAudio;
    
    AudioSource m_audio;

    public void Start()
    {
        m_audio = GetComponent<AudioSource>();
    }

    public void PlayEndingAudio()
    {
        m_audio.clip = endingAudio;
        m_audio.Play();
    }

    public void PlayDefaultAudio()
    {
        m_audio.clip = defaultAudio;
        m_audio.Play();
    }
}
