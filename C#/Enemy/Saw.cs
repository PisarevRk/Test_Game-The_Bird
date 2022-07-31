using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public GameObject effect;
    public Sounds sounds;
    public int i_sound;
    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Box")
        {
            Instantiate(effect, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            if (sounds.onSounds == true)
            {
                sounds.arreyOfSounds[i_sound - 1].Play();
            }
        }
    }
        // Update is called once per frame
    void Update()
    {
        
    }
}
