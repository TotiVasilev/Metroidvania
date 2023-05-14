using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BasicEnemyController : MonoBehaviour
{
    
    private LevelSystem levelSystem;
    
    public Sprite HitRenderer;
    public Sprite NormalRenderer;
    public SpriteRenderer rend;
    public MovePlayer playerMovement;
    private enum State
    {
        Moving,
        Knockback,
        Attack,
        Dead
    }

    private State currentState;

    [SerializeField]
    private float
        groundCheckDistance,
        wallCheckDistance,
        playerCheckDistance,
        movementSpeed,
        maxHealth,
        knockbackDuration;
    [SerializeField]
    private Transform
        groundCheck,
        wallCheck,
        playerCheck;
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private LayerMask whatIsPlayer;
    [SerializeField]
    private Vector2 knockbackSpeed;
    [SerializeField]
    private GameObject
        hitParticle,
        deathChunkParticle,
        deathBloodParticle;

    private float 
        currentHealth,
        knockbackStartTime;

    private int 
        facingDirection,
        damageDirection;

    private Vector2 movement;

    private bool
        groundDetected,
        wallDetected,
        playerDetected;

    [SerializeField] private GameObject alive;
    private Rigidbody2D aliveRb;
    private Animator aliveAnim;

    public bool playerInRange;

    private void Start()
    {
        alive = this.gameObject;
        aliveRb = alive.GetComponent<Rigidbody2D>();
        aliveAnim = alive.GetComponent<Animator>();

        currentHealth = maxHealth;
        facingDirection = 1;
        rend = gameObject.GetComponent<SpriteRenderer>();
        
        
    }

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerMovement.KBCounter = playerMovement.KBTotalTime;
            if(collision.transform.position.x <= transform.position.x)
            {
                playerMovement.KnockFromRight = true;
            }

            if(collision.transform.position.x >= transform.position.x)
            {
                playerMovement.KnockFromRight = false;
            }
        }

        
    }
    private void Update()
    {
        playerDetected = Physics2D.Raycast(playerCheck.position, transform.right, playerCheckDistance, whatIsPlayer);
        switch (currentState)
        {
            case State.Moving:
                UpdateMovingState();
                break;
            case State.Knockback:
                UpdateKnockbackState();
                break;
            case State.Attack:
                UpdateAttackState();
                break;
            case State.Dead:
                UpdateDeadState();
                break;
        }
    }

    //--WALKING STATE--------------------------------------------------------------------------------

    private void EnterMovingState()
    {
        
    }

    private void UpdateMovingState()
    {
        groundDetected = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        wallDetected = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);
        

        if (playerDetected)
        {

            SwitchState(State.Attack);
        }

        if (!groundDetected || wallDetected)
        {
            Flip();
        }
        else
        {
            movement.Set(movementSpeed * facingDirection, aliveRb.velocity.y);
            aliveRb.velocity = movement;
        }
    }

    private void ExitMovingState()
    {

    }

    //--KNOCKBACK STATE-------------------------------------------------------------------------------

    private void EnterKnockbackState()
    {
        rend.sprite = HitRenderer;
        knockbackStartTime = Time.time;
        movement.Set(knockbackSpeed.x * damageDirection, knockbackSpeed.y);
        aliveRb.velocity = movement;
        //aliveAnim.SetBool("Knockback", true);

       
      

    }

    private void UpdateKnockbackState()
    {
        if(Time.time >= knockbackStartTime + knockbackDuration)
        {
            SwitchState(State.Moving);
        }

        
    }

    private void ExitKnockbackState()
    {
        rend.sprite = NormalRenderer;
        //aliveAnim.SetBool("Knockback", false);
    }

    //--DEAD STATE---------------------------------------------------------------------------------------

    private void EnterDeadState()
    {
        Destroy(gameObject);
        levelSystem.AddExperience(120);
    }

    private void UpdateDeadState()
    {

    }

    private void ExitDeadState()
    {
        
    }

    // ATTACK STATE
    private void EnterAttackState()
    {
        Debug.Log("EnterAttackState");
    }

    private void UpdateAttackState()
    {
        if (!playerDetected)
        {
            Debug.Log("PlayerNotInRange");
            SwitchState(State.Moving);
        }
    }

    private void ExitAttackState()
    {
        Debug.Log("LeavingAttackState");
    }

    //--OTHER FUNCTIONS--------------------------------------------------------------------------------

    private void Damage(float[] attackDetails)
    {
        currentHealth -= attackDetails[0];

        //Instantiate(hitParticle, alive.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));

        if(attackDetails[1] > alive.transform.position.x)
        {
            damageDirection = -1;
        }
        else
        {
            damageDirection = 1;
        }

        //Hit particle

        if(currentHealth > 0.0f)
        {
            SwitchState(State.Knockback);
        }
        else if(currentHealth <= 0.0f)
        {
            SwitchState(State.Dead);
        }
    }

    private void Flip()
    {
        facingDirection *= -1;
        alive.transform.Rotate(0.0f, 180.0f, 0.0f);

    }

    private void SwitchState(State state)
    {
        switch (currentState)
        {
            case State.Moving:
                ExitMovingState();
                break;
                case State.Attack:
                ExitAttackState();
                break;
            case State.Knockback:
                ExitKnockbackState();
                break;
            
            case State.Dead:
                ExitDeadState();
                break;
        }

        switch (state)
        {
            case State.Moving:
                EnterMovingState();
                break;
                case State.Attack:
                EnterAttackState();
                break;
            case State.Knockback:
                EnterKnockbackState();
                break;
            
            case State.Dead:
                EnterDeadState();
                break;
        }

        currentState = state;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
        Gizmos.DrawLine(playerCheck.position, new Vector2(playerCheck.position.x + playerCheckDistance, playerCheck.position.y));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D()
    {
        playerInRange = false;
    }
}
