using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public RotatingPlatform[] rotatingPlatform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            for (int i = 0; i < rotatingPlatform.Length; i++)
            {
                rotatingPlatform[i].open = true;
            }

        }
    }
}
