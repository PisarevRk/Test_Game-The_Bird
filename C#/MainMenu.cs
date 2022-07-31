using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject levelUi;
    public LevelController levelController;
    public Toggle tutorialtoggle;
    public Toggle soundtoggle;
    public Toggle musictoggle;
    public GameObject settingsUi;
    void Start()
    {
        //print(PlayerPrefs.GetInt("Tutorial"));
        levelUi.SetActive(false);
        settingsUi.SetActive(false);

        int tutorial = PlayerPrefs.GetInt("Tutorial");
        switch (tutorial)
        {
            case 1:
                tutorialtoggle.isOn = false;
                break;
            case 0:
                tutorialtoggle.isOn = true;
                break;
        }

        int sound = PlayerPrefs.GetInt("Sound");
        switch (sound)
        {
            case 1:
                soundtoggle.isOn = false;
                break;
            case 0:
                soundtoggle.isOn = true;
                break;
        }

        int music = PlayerPrefs.GetInt("Music");
        switch (music)
        {
            case 1:
                musictoggle.isOn = false;
                break;
            case 0:
                musictoggle.isOn = true;
                break;
        }
    }

    public void LevelMenu()
    {
        levelUi.SetActive(true);
        levelController.StartUi();
    }
    public void OnOffTutorial()
    {
        if (tutorialtoggle.isOn == true)
        {
            PlayerPrefs.SetInt("Tutorial", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Tutorial", 1);
        }
    }
    public void OnOffSound()
    {
        if (soundtoggle.isOn == true)
        {
            PlayerPrefs.SetInt("Sound", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 1);
        }
    }
    public void OnOffMusic()
    {
        if (musictoggle.isOn == true)
        {
            PlayerPrefs.SetInt("Music", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Music", 1);
        }
    }

    public void Settings()
    {
        settingsUi.SetActive(true);
    }

   

}
