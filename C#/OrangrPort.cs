using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangrPort : MonoBehaviour
{
    public BluePort bluePort;
    public Sounds sounds;
    public bool isGo = true;
    public int i_sound;
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (isGo)
        {
            other.transform.position = new Vector2(bluePort.transform.position.x, bluePort.transform.position.y);
            sounds.arreyOfSounds[i_sound - 1].Play();
            bluePort.isGo = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        isGo = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
