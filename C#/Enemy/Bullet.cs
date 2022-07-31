using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    private float lifeTtime;
    public float distance;
    public LayerMask whatIsSolid;
    public GameObject effect;
    private GameObject effect1;


    void Start()
    {
        lifeTtime = lifeTime;
    }
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.GetComponent<PlayerMove>().Dead();
            }
            effect1 = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(effect1, 1f);
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (lifeTime <= 0)
        {
            effect1 = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(effect1, 1f);
            lifeTime = lifeTtime;
        }
        else
        {
            lifeTime -= Time.deltaTime;
        }
    }
}
