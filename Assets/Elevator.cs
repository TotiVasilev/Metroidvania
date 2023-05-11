using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform player;
    public Transform elevatorSwitch;
    public Transform downPos;
    public Transform upperPos;

    public float speedToGoElevator;
    bool isElevatorDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.position, elevatorSwitch.position) > 0.5f && Input.GetKeyDown(KeyCode.R))
        {
            if (transform.position.y <= downPos.position.y)
            {
                isElevatorDown = true;

            }
            else if (transform.position.y >= upperPos.position.y)
            {
                isElevatorDown = false;
            }
        }

        if (isElevatorDown)
        {
            transform.position = Vector2.MoveTowards(transform.position, upperPos.position, speedToGoElevator * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, downPos.position, speedToGoElevator * Time.deltaTime);
        }
        
    }

    void StartElevator()
    {
        if(Vector2.Distance(player.position, elevatorSwitch.position) > 0.5f && Input.GetKeyDown(KeyCode.R))
        {
            if(transform.position.y <= downPos.position.y)
            {
                isElevatorDown = true;

            }
            else if(transform.position.y >= upperPos.position.y)
            {
                isElevatorDown = false;
            }
        }

        if(isElevatorDown)
        {
            transform.position = Vector2.MoveTowards(transform.position, upperPos.position, speedToGoElevator * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, downPos.position, speedToGoElevator * Time.deltaTime);
        }

    }
}
