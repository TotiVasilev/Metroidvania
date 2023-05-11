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


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && canUp == true)
        {
            isMoving = true;
        }

        if(isMoving == true)
        {
            this.GetComponent<SpriteRenderer>().sprite = isActivated;
            transform.position = Vector2.MoveTowards(transform.position, goToPosition, 0.005f);
        }

        if (Input.GetKeyDown(KeyCode.K) && isMoving==true)
        {
            isMovingDown = true;

        }

        if(isMovingDown)
        {
            transform.position = Vector2.MoveTowards( goToPosition, startPosition, 0.005f);
            
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



}
