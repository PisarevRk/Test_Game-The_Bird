using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMusic : MonoBehaviour
{
    public AudioSource musicSound;
    public bool onMusic = true;
    private bool musicStart = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int music = PlayerPrefs.GetInt("Music");

        switch (music)
        {
            case 1:
                onMusic = false;
                break;
            case 0:
                onMusic = true;
                break;
        }

        if (onMusic == true && musicStart == false)
        {
            musicSound.Play();
            musicStart = true;
        }
        if (onMusic == false && musicStart == true)
        {
            musicSound.Stop();
            musicStart = false;
        }
    }
}
