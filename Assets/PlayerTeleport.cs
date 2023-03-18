using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;// the teleporter that will trigger the teleport
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Teleporter"))// if our player makes collision with an object with tag Teleporter
        {
            currentTeleporter = collision.gameObject;//this object becomes Current teleporter
        }
        
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag(tag: "Teleporter"))//if our player isnt making contact with an object with tag Teleporter
        {
            if(collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null; // this object is no longer Current teleporter
            }
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            //Teleport to the other teleporter 
            if(currentTeleporter !=null)//only if there is an current teleporter active 
            {
                transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
            }
            
        }
    }

    
}
