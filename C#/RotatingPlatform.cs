using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    public bool open = false;
    public Transform transform;
    public Vector3 direction;
    public float speed;
    public float time;
    private float ttime;
    void Start()
    {
        ttime = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (open == true)
        {
            if (time > 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
                time -= Time.deltaTime;
            }
        }
        if (open == false)
        {
           if (time <= ttime)
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position - direction, speed * Time.deltaTime);
                time += Time.deltaTime;
            }
        }
    }
    public void Open()
    {
        open = true;
    }
    
}
