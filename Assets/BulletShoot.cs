using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // rigidbody reference
        rb.velocity = transform.right * speed;  //fire direction
        Destroy(gameObject,3f);//destroy the fired object after 3 sec
    }

    
}
