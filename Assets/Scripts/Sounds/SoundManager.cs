using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }
    [SerializeField] private AudioSource soundEffect;
    [SerializeField] private AudioSource soundMusic;
    
    [SerializeField] public SoundType[] sounds;


    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

private void Start()
{
    PlayBgMusic(Sounds.BgMusic);
}
public void PlayBgMusic(Sounds sound)
{
    AudioClip clip = getSoundClip(sound);
    if (clip != null)
    {
        soundMusic.clip = clip;
        soundMusic.Play();
    }
    else
    {
        Debug.LogError("Clip not found for soundtype: " + sound);
    }
}

public void Play(Sounds sound)
{
    AudioClip clip = getSoundClip(sound);
    if (clip != null)
    {
        soundEffect.clip = clip;
        soundEffect.PlayOneShot(clip);
    }
    else
    {
        Debug.LogError("Clip not found for soundtype: " + sound);
    }
}

private AudioClip getSoundClip(Sounds sound)
{
    SoundType soundItems = Array.Find(sounds, item => item.soundType == sound);
    if (soundItems != null) return soundItems.soundclip;
    return null;
}
}
[SerializeField]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundclip;
}

public enum Sounds
{
    ButtonClick,
    PlayerMove,
    PlayerDeath,
    EnemyDeath,
    BgMusic


}
