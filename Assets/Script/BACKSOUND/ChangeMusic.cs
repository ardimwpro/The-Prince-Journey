using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    public int indexMusic;

    void Start()
    {
        if (GameObject.Find("BgMusic") != null)
        {
            MusicControl.Instance.ChangeMusic(indexMusic);
        }
    }

    // Update is called once per frame
    void update()
    {

    }
}
