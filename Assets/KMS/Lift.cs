using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public Sprite notActivated;
    public Sprite isActivated;

    public bool canUp = false;
    public bool isMoving = false;
    public bool isMovingDown = false;
    public Vector2 goToPosition;
    public Vector2 startPosition;
    public float LiftSpeed;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && canUp == true )
        {
            isMovingDown = false;
            isMoving = true;
        }

        

        
    }

    private void FixedUpdate()
    {
        if (isMoving == true)
        {

            this.GetComponent<SpriteRenderer>().sprite = isActivated;
            transform.position = Vector2.MoveTowards(transform.position, goToPosition, LiftSpeed);
            StartCoroutine(LiftDown(5));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<CheckpointController>();
        if(player!=null)
        {
            canUp = true;

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var player = other.GetComponent<CheckpointController>();
        if(player!=null)
        {
            canUp = false;

        }

    }

    IEnumerator LiftDown( float goBackAfter)
    {
        yield return new WaitForSeconds(goBackAfter);
        LiftReturn();
    }

    private void LiftReturn()
    {
        isMovingDown = true;

        if (isMovingDown)
        {
            this.GetComponent<SpriteRenderer>().sprite = notActivated;
            isMoving = false;

            transform.position = Vector2.MoveTowards(transform.position, startPosition, LiftSpeed);

        }
    }


}
