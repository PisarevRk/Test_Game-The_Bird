using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public PlayerMove player;
    public Bullet bullet;
    public Transform shotPoint;
    private Transform transform;
    private Animator animator;
    public float shotTime;
    private float shotTtime;
    public float rotation;
    public bool isOn = true;
    void Start()
    {
        transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        shotTtime = shotTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            gameObject.tag = "Turret";
            animator.Play("On");
            float x = player.transform.position.x - transform.position.x;
            float y = (player.transform.position.y - transform.position.y) - 0.3f;
            rotation = Mathf.Atan2(x, y) * Mathf.Rad2Deg;
            Quaternion target = Quaternion.Euler(0, 0, -rotation);
            if (shotTime <= 0)
            {
                Instantiate(bullet, shotPoint.position, target);
                shotTime = shotTtime;
            }
            else
            {
                shotTime -= Time.deltaTime;
            }
        }
        else
        {
            gameObject.tag = "Untagged";
            animator.Play("Off");
        }
        
    }
}
