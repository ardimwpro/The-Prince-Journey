using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; // Gunakan 'static' agar dapat diakses tanpa pembuatan instans

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

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
        return;
    }

    // Mengatur volume musik dan SFX dari PlayerPrefs (jika ada)
    float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f); // 1f adalah nilai default jika tidak ada pengaturan sebelumnya
    float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

    MusicVolume(musicVolume);
    SFXVolume(sfxVolume);
}


    private void Start()
    {
       
    }

    public void PlayMusic(string name)
    {
        Sound s = System.Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Music not found: " + name);
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = System.Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("SFX not found: " + name);
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

}

