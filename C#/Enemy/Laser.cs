using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Animator animator;
    public PlayerMove player;
    public float workTime;
    public float sleepTime;
    private float workTtime;
    private float sleepTtime;
    public bool isOn;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        workTtime = workTime;
        sleepTtime = sleepTime;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (isOn)
            {
                player.Dead();
            }
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            animator.Play("Idle");
            workTime -= Time.deltaTime;
            if (workTime <= 0)
            {
                isOn = false;
                workTime = workTtime;
            }
        }
        else
        {
            animator.Play("Off");
            sleepTime -= Time.deltaTime;
            if (sleepTime <= 0)
            {
                isOn = true;
                sleepTime = sleepTtime;
            }
        }
    }
}
