using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource[] arreyOfSounds;
    public bool onSounds;
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        int sound = PlayerPrefs.GetInt("Sound");

        if (sound == 0)
        {
            onSounds = true;
        }
        else
        {
            onSounds = false;
        }
    }
}
