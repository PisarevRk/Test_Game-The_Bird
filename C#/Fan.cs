using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public Vector2 direction;
    public float force;
    private Rigidbody2D objectRb;
    private Transform objectTransform;
    private Animator animator;
    private Transform transform;
    public float workTime;
    public float sleepTime;
    private float workTtime;
    private float sleepTtime;
    private bool isOn = true;
    void Start()
    {
        transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        workTtime = workTime;
        sleepTtime = sleepTime;
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        objectRb = other.GetComponent<Rigidbody2D>();
        objectTransform = other.GetComponent<Transform>();
        float y = transform.position.y - objectTransform.position.y;
        float x = transform.position.x - objectTransform.position.x;
        if (isOn)
        {
            if (direction.x != 0)
            {
                objectRb.AddForce(direction.normalized * (force / Mathf.Abs(x)));
            }
            else if (direction.y != 0)
            {
                objectRb.AddForce(direction.normalized * (force / Mathf.Abs(y)));
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
       if (isOn)
       {
            workTime -= Time.deltaTime;
            if (workTime <= 0)
            {
                isOn = false;
                animator.Play("Off");
                workTime = workTtime;
            }
       }
       else
       {
            sleepTime -= Time.deltaTime;
            if (sleepTime <= 0)
            {
                isOn = true;
                animator.Play("On");
                sleepTime = sleepTtime;
            }
       }
    }
}
