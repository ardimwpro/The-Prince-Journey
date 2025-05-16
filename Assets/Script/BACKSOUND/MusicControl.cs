using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public static MusicControl Instance { get; set; }

    public AudioClip[] clipMusic;
    public AudioSource audioMusic;

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
        }
    }

    public void ChangeMusic(int indexMusic)
    {
        if (audioMusic.clip != clipMusic[indexMusic])
        {
            audioMusic.Stop();

            audioMusic.clip = clipMusic[indexMusic];

            audioMusic.Play();
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
