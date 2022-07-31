using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUi : MonoBehaviour
{
    public GameObject tutorialUi;
    public PlayerMove player;
    public bool tutorialOn = true;
    // Start is called before the first frame update
    void Start()
    {
        int tutorial = PlayerPrefs.GetInt("Tutorial");
        if (tutorial == 1)
        {
            tutorialOn = false;
        }
        else
        {
            tutorialOn = true;
        }
        if (tutorialOn == true)
        {
            player.blockMove = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorialOn == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                tutorialUi.SetActive(false);
                player.blockMove = false;
            }
        }
        else
        {
            tutorialUi.SetActive(false);
        }
    }
}
