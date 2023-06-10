using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Rigidbody2D rb;
    public float attackMoveDistance = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.FindObjectOfType<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(Input.GetMouseButton(0))
        {
            rb.AddForce(new Vector2(attackMoveDistance, 0f), ForceMode2D.Impulse);
            Debug.Log("Move");
        }
    }
}
