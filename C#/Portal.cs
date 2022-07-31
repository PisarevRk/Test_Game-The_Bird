using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Transform transform;
    public GameObject bluePort;
    public GameObject orangePort;
    public bool isBlue;
    public float distanse = 0.3f;
    private bool isGo = true;
    void Start()
    {  
        transform = GetComponent<Transform>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isBlue)
        {
            
            other.transform.position = new Vector2(bluePort.transform.position.x, bluePort.transform.position.x);
        }
        else
        {
            other.transform.position = new Vector2(orangePort.transform.position.x, orangePort.transform.position.x);
        }
    }
    void Update()
    {
        
    }
}
