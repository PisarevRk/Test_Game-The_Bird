using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsControll : MonoBehaviour
{
    public GameObject settingUi;
    public LevelController levelController;
    
    public void Back()
    {
        settingUi.SetActive(false);
    }
    public void Reset()
    {
        for (int i = 1; i < levelController.levels.Length; i++)
        {
            levelController.levels[i].interactable = false;

            PlayerPrefs.DeleteKey($"Level{i}Time");
        }
        PlayerPrefs.DeleteKey("LevelComplete");
    }
    public void Recover()
    {
        PlayerPrefs.SetInt("LevelComplete", levelController.levels.Length);
    }
}
