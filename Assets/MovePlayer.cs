using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovePlayer : MonoBehaviour
{
    [Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }
    private float horizontal;// A,D || < > movement
    private float vertical;
    public float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;//sprite profile = horizontal direction

    private float coyoteTime = 0.15f;// still being able to jump shortly after leaving the platform
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.15f;// registering jump shortly before entering the platform
    private float jumpBufferCounter;

    public Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;//every collision with object in this layer = IsGrounded
    bool run; 
    public AudioSource foosteps;


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    //Checking if we can jump
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);//creating a sphere around the empty grouch check object
        
    }

    void StartRun()
        {
            if(run)
            {
              animator.SetFloat("Running", Math.Abs(horizontal));
            }
        }
        

    void Update()
    {
        //Horizontal movement
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw ("Vertical");
        
       
        
        Flip();//sprite update

        StartRun();

        if (IsGrounded())//Coyote update
        {
            
            animator.SetFloat("Running", Math.Abs(horizontal));
            
            animator.SetBool("Jumping", false);

            coyoteTimeCounter = coyoteTime;// = 0, grounded
            
        }
        else
        {
            animator.SetFloat("Running", Math.Abs(0));
            coyoteTimeCounter -= Time.deltaTime;// leaving the ground, start counting for coyote time
            animator.SetBool("Jumping", true);
            
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
            animator.SetBool("Jumping", true);
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

            coyoteTimeCounter = 0f;
        }
    }

   public void OnLanding()
   {
    
  
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
