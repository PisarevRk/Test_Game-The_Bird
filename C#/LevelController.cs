using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public Button[] levels;
    public GameObject levelUi;
    int levelComplete;
    public void StartUi()
    {
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        for (int i = 1; i < levels.Length; i++)
        {
            levels[i].interactable = false;
        }
        for (int i = 0; i < levelComplete; i++)
        {
            levels[i].interactable = true;
            if (levelComplete != levels.Length)
            {
                levels[i+1].interactable = true;
            }
        }
    }

    public void LoadTo(int level)
    {
        SceneManager.LoadScene(level);
    }
    
    public void Back()
    {
        levelUi.SetActive(false);
    }

}
