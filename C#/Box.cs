using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public PlayerMove player;
    private HingeJoint2D hinge;
    private bool isTouch = false;
    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
        hinge.enabled = false;
    }

    void Update()
    {
        if (player.isGrab == true && isTouch == true)
        {
            hinge.enabled = true;
        }
        else
        {
            hinge.enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.grabButton.SetActive(true);
            isTouch = true;  
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.grabButton.SetActive(false);
            isTouch = false;
            player.Drop();
        }
    }
}
