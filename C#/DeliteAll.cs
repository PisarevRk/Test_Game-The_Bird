using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliteAll : MonoBehaviour
{
    private int tap = 0;
    public float time = 0;
    private float ttime = 3f;
    public void Destroy()
    {
        tap += 1;
        if (tap == 1)
        {
            time = ttime;
        }
        if (tap == 5)
        {
            print("DESTROY!!!");
            PlayerPrefs.DeleteAll();
        }
    }
    public void Update()
    {

        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        if (time <= 0)
        {
            tap = 0;
        }
    }
}
