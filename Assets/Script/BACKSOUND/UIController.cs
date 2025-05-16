using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;

    private void Awake()
{
    
    float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f); // 1f adalah nilai default jika tidak ada pengaturan sebelumnya
    float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

    _musicSlider.value = musicVolume;
    _sfxSlider.value = sfxVolume;
}

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }

   public void MusicVolume()
{
    float volume = _musicSlider.value;
    AudioManager.Instance.MusicVolume(volume);
    PlayerPrefs.SetFloat("MusicVolume", volume); // Save music volume to PlayerPrefs
    PlayerPrefs.Save(); // Save PlayerPrefs data immediately
}

public void SFXVolume()
{
    float volume = _sfxSlider.value;
    AudioManager.Instance.SFXVolume(volume);
    PlayerPrefs.SetFloat("SFXVolume", volume); // Save SFX volume to PlayerPrefs
    PlayerPrefs.Save(); // Save PlayerPrefs data immediately
}


}
