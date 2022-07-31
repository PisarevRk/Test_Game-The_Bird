using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePort : MonoBehaviour
{
    public OrangrPort orangePort;
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
            other.transform.position = new Vector2(orangePort.transform.position.x, orangePort.transform.position.y);
            sounds.arreyOfSounds[i_sound - 1].Play();
            orangePort.isGo = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        isGo = true;
    }
        // Update is called once per frame
        
}
