using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueButton : MonoBehaviour
{
    public Animator animator;
    public RotatingPlatform[] rotatingPlatform;
    public HingeJoint2D[] hingeJoints;
    public BoxCollider2D boxCollider2D;
    private bool isActive = false;
    public Sounds sounds;
    public int i_sound;
    void Start()
    {
        animator.Play("DontActive");  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Box")
        {
            if (isActive == false)
            {
                float x = boxCollider2D.offset.x;
                float y = boxCollider2D.offset.y;
                boxCollider2D.offset = new Vector2(x, y - 0.12f); 
                animator.Play("Active");
                for (int i = 0; i < rotatingPlatform.Length; i++)
                {
                    rotatingPlatform[i].open = true;
                }
                for (int i = 0; i < hingeJoints.Length; i++)
                {
                    hingeJoints[i].useMotor = true;
                }
                if (sounds.onSounds == true)
                {
                    sounds.arreyOfSounds[i_sound-1].Play();
                }
                
            }
            if (isActive == false)
            {
                isActive = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Box")
        {
            if (isActive == true)
            {
                float x = boxCollider2D.offset.x;
                float y = boxCollider2D.offset.y;
                boxCollider2D.offset = new Vector2(x, y + 0.12f);
                for (int i = 0; i < rotatingPlatform.Length; i++)
                {
                    rotatingPlatform[i].open = false;
                }
                for (int i = 0; i < hingeJoints.Length; i++)
                {
                    hingeJoints[i].useMotor = false;
                }
                animator.Play("DontActive");
                if (sounds.onSounds == true)
                {
                    sounds.arreyOfSounds[i_sound-1].Play();
                }
            }
            if (isActive == true)
            {
                isActive = false;
            }
        }
    }
}
