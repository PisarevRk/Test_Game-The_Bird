using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{

    void Start()
    {
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
    public void Next()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex + 1);
    }
}
