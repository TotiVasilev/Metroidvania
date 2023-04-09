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
    
    public bool isAttacking = false;
    public static MovePlayer instance;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 10;

    public bool attack2;
    public bool attack3 = false;
    public Transform attackPoint3;
    public float attackRange3 = 0.5f;
    public int attackDamage3 = 20;

    public GameObject HitBox;
    public GameObject HitBox3;


    

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        HitBox.SetActive(true);
        HitBox3.SetActive(false);
            
    }

    //Checking if we can jump
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);//creating a sphere around the empty grouch check object
        
    }

    void StartRun()
        {
            if(!isAttacking)
            {
                horizontal = Input.GetAxisRaw("Horizontal");
              animator.SetFloat("Running", Math.Abs(horizontal));
              
            }
           
        }
        

    void Update()
    {
        

        Attack();
        //Horizontal movement
    
        
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

    void Attack()
    {
        

        if (Input.GetKeyDown(KeyCode.R) && !isAttacking)
        {
            isAttacking = true;
           
            
            HitBox.SetActive(true);
            HitBox3.SetActive(false);
            
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
                foreach(Collider2D enemy in hitEnemies)
                {
                    //Enemy is the script, not the object
                    enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                    
                }
            

            if (attack3)
            {
               HitBox.SetActive(false);
               HitBox3.SetActive(true);
                
                Collider2D[] hitEnemies3 = Physics2D.OverlapCircleAll(attackPoint3.position, attackRange3, enemyLayers);
                foreach(Collider2D enemy in hitEnemies3)
                {
                    enemy.GetComponent<Enemy>().TakeDamage(30);
                    Debug.Log("Attack3");
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawWireSphere(attackPoint3.position, attackRange3);
       
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
