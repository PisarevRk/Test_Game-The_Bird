using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUi;
    public bool pauseActive = false;

    void Start()
    {
        Time.timeScale = 1f;
        pauseUi.SetActive(false);
    }

    public void OnPause()
    {
        Time.timeScale = 0f;
        pauseUi.SetActive(true);
    }
    public void OffPause()
    {
        Time.timeScale = 1f;
        pauseUi.SetActive(false);
    }
}
