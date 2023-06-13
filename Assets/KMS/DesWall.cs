using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesWall : MonoBehaviour
{
    public bool canBeDes = false;

    public GameObject fowA1;
    public GameObject fowA2;
    public GameObject fowA3;

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void destroyWalls()
    {
        if (canBeDes == true)
        {
            if (fowA1 != null)
            {
                fowA1.GetComponent<Animator>().SetTrigger("deac");
            }
            if (fowA2 != null)
            {
                fowA2.GetComponent<Animator>().SetTrigger("deac");
            }
            if (fowA3 != null)
            {
                fowA3.GetComponent<Animator>().SetTrigger("deac");
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<CheckpointController>();
        if(player!=null)
        {
            canBeDes = true;

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var player = other.GetComponent<CheckpointController>();
        if(player!=null)
        {
            canBeDes = false;

        }

    }

}
