using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private float horizontal;// A,D || < > movement
    public float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;//sprite profile = horizontal direction

    private float coyoteTime = 0.15f;// still being able to jump shortly after leaving the platform
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.15f;// registering jump shortly before entering the platform
    private float jumpBufferCounter;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;//every collision with object in this layer = IsGrounded


    //Checking if we can jump
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);//creating a sphere around the empty grouch check object
    }

    void Update()
    {
        //Horizontal movement
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();//sprite update


        if (IsGrounded())//Coyote update
        {
            coyoteTimeCounter = coyoteTime;// = 0, grounded
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;// leaving the ground, start counting for coyote time
        }

        if (Input.GetButtonDown("Jump"))//Jump buffer update
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        //Reseting jump buffer after jumping 
        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

            jumpBufferCounter = 0f;
        }

        //Reseting coyote time after jumping
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

            coyoteTimeCounter = 0f;
        }
    }

    private void FixedUpdate()// physics in Fixed update
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        //Calculating the position of the sprite depending on Horizontal input
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;// if isFacingRight = true, pressing "A" or < will = !isFacingRight
            //flipping the sprite
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }




}
