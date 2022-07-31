using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSaw : MonoBehaviour
{
    public Transform transform;
    public Vector3 direction;
    public float speed;
    public float time;
    private bool moveForward = true;
    private float ttime;
    void Start()
    {
        ttime = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveForward == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
            time -= Time.deltaTime;
            if (time < 0)
            {
                moveForward = false;
            }
        }
        if (moveForward == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position - direction, speed * Time.deltaTime);
            time += Time.deltaTime;
            if (time > ttime)
            {
                moveForward = true;
            }
        }
    }
}
