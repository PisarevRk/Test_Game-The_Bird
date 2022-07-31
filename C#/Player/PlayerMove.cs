using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Vector2 direction;
    //public Vector2 boxDirection;
    private Rigidbody2D rigidbody;
    private Animator animator;
    private Transform transform;
    public GameObject tutorialUi;
    public GameObject grabButton;
    public GameObject dropButton;
    public AudioSource bgMusic;
    public Sounds sounds;
    private MoveState moveState = MoveState.Idle;
    private DirectionState directionState = DirectionState.Right;
    private float flipAudioTime = 0, flipAudioCooldown = 0.2f;
    public float dontBoxForce;
    public float boxForce;
    private float force;
    private float Yposition;
    public bool isGrab = false;
    public bool isDead = false;
    public bool blockMove = false;
    public bool immortal = false;
    private int directionFlight;
    public bool onTutorial;
    public int i_sound;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        grabButton.SetActive(false);
        dropButton.SetActive(false);
        force = dontBoxForce;
        if (onTutorial == true)
        {
            tutorialUi.SetActive(true);
        }
    }
    void Update()
    {
        
    }
    IEnumerator Example()
    {
        float y1 = transform.position.y;
        yield return new WaitForSecondsRealtime(0.1f);
        float y2 = transform.position.y;
        Yposition = y1 - y2;
        if (Yposition > 0.1)
        {
            directionFlight = 0;
        }
        else if (Yposition < -0.1)
        {
            directionFlight = 1;
        }
        else
        {
            directionFlight = 2;
        }
    }
    void FixedUpdate()
    {
        StartCoroutine(Example());
        if (blockMove == false)
        {
            if (Input.GetKey(KeyCode.D) || moveState == MoveState.FlyRight)
            { 
                rigidbody.velocity = Vector2.zero;
                direction.x = 1;
                direction.y = 2;
                rigidbody.AddForce(direction.normalized * force, ForceMode2D.Impulse);
                if (directionState == DirectionState.Left)
                {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }
                directionState = DirectionState.Right;
                /*   звук взмаха крыла
                if (onSound == true)
                {
                    flipAudioTime -= Time.deltaTime;
                    if (flipAudioTime <= 0)
                    {
                        flip.Play();
                        flipAudioTime = flipAudioCooldown;
                    }
                }
                */ 
            }  
            if (Input.GetKey(KeyCode.A) || moveState == MoveState.FlyLeft)
            {
                rigidbody.velocity = Vector2.zero;
                direction.x = -1;
                direction.y = 2;
                rigidbody.AddForce(direction.normalized * force, ForceMode2D.Impulse);
                if (directionState == DirectionState.Right)
                {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }
                directionState = DirectionState.Left;
                /*    звук взмаха крыла
                if (onSound == true)
                {
                    flipAudioTime -= Time.deltaTime;
                    if (flipAudioTime <= 0)
                    {
                        flip.Play();
                        flipAudioTime = flipAudioCooldown;
                    }
                }
                */ 
            }
            //print(directionFlight);
            if (directionFlight == 1)
            {
                animator.Play("Fly");
            }
            else if(directionFlight == 0)
            {
                animator.Play("Drop");
            }
            else
            {
                animator.Play("Idle");
            }
        }
        moveState = MoveState.Idle;
    }
    public void  FlyLeft()
    {
        //print("FlyLeft");
        moveState = MoveState.FlyLeft;

    }
    public void  FlyRight()
    {
        //print("FlyRight");
        moveState = MoveState.FlyRight;
    }
    
    public void Grab()
    {
        if (isDead == false)
        {
            isGrab = true;
            grabButton.SetActive(false);
            dropButton.SetActive(true);
            force = boxForce;
        }
    }
    public void  Drop()
    {
        if (isDead == false)
        {
            isGrab = false;
            dropButton.SetActive(false);
            force = dontBoxForce;
        }
    }
    /*void OnTriggerStay2D(Collider2D other)
    {
        if (isDead == false)
        {
            if (other.gameObject.tag != "Box")
            {
                animator.Play("Idle");
            }
        }
    }*/

    // нужно это повесить на кактус ================================================================
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Dead();
        }
    }
    public void Dead()
    {   
        if (!isDead)
        {
            if (sounds.onSounds == true)
            {
                sounds.arreyOfSounds[i_sound - 1].Play();
            }
        }
        if (immortal == false)
        {
            blockMove = true;
            isDead = true;
            if (isGrab == true)
            {
                isGrab = false;
                dropButton.SetActive(false);
                rigidbody.gravityScale = 1;

            }
            if (directionState == DirectionState.Right)
            {
                direction.x = -1;
                direction.y = 2;
                force = force / 2;
                rigidbody.AddForce(direction.normalized * force, ForceMode2D.Impulse);
            }
            else
            {
                direction.x = 1;
                direction.y = 2;
                force = force / 2;
                rigidbody.AddForce(direction.normalized * force, ForceMode2D.Impulse);
            }
            rigidbody.AddForce(direction.normalized * force, ForceMode2D.Impulse);
            bgMusic.Stop();
            animator.Play("Die");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Dead();
        }
    }
    // ===============================================================================================
    enum DirectionState
    {
        Right,
        Left
    }

    enum MoveState
    {
        Idle,
        FlyLeft,
        FlyRight,
        Drop,
        Die
    }
}
    

