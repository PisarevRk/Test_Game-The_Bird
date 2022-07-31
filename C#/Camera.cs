using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{ 
    private Transform transform;
    public PlayerMove player;
    private bool isRight = false;
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        if (player.transform.position.x >= 9 && isRight == false)
        {
            transform.position = new Vector2(transform.position.x + 17.7f, transform.position.y);
            isRight = true;
        }
        if (player.transform.position.x <= 9 && isRight == true)
        {
            transform.position = new Vector2(transform.position.x - 17.7f, transform.position.y);
            isRight = false;
        }
    }
}
