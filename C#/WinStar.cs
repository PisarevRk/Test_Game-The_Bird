using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinStar : MonoBehaviour
{
    public GameObject winUi;
    public PlayerMove player;
    public Sounds sounds;
    Text[] data1;
    Text textScore;
    Text textBestScore;
    public int i_sound;
    public float time;
    public float floatScore;
    void Start()
    {
        time = 0;

        winUi.SetActive(false);
        data1 = winUi.GetComponentsInChildren<Text>();
        for (int i = 0; i < data1.Length; i++)
        {
            if (data1[i].tag == "Score") textScore = data1[i];
            if (data1[i].tag == "BestScore") textBestScore = data1[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (player.blockMove == false)
            time += Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (player.isDead == false)
            {
                winUi.SetActive(true);
                player.blockMove = true;
                player.immortal = true;
                if (sounds.onSounds == true)
                {
                    sounds.arreyOfSounds[i_sound-1].Play();
                }
                floatScore = Mathf.Round(time * 10.0f) * 0.1f;
                textScore.text = (Mathf.Round(time * 10.0f) * 0.1f).ToString();


                int sceneIndex = SceneManager.GetActiveScene().buildIndex;

                if (floatScore < PlayerPrefs.GetFloat($"Level{sceneIndex}Time") || PlayerPrefs.GetFloat($"Level{sceneIndex}Time") == 0)
                    PlayerPrefs.SetFloat($"Level{sceneIndex}Time", floatScore);

                textBestScore.text = (PlayerPrefs.GetFloat($"Level{sceneIndex}Time")).ToString();

                if (PlayerPrefs.GetInt("LevelComplete") < sceneIndex)
                {
                    PlayerPrefs.SetInt("LevelComplete", sceneIndex);
                }

            }
        }
    }
}
