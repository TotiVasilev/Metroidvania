using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite notActivated;
    public Sprite isActivated;

    public GameObject[] checkpoints;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<CheckpointController>();
        if(player!=null)
        {
            player.startPos = transform.position;


        checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");

        foreach (GameObject checkpoint in checkpoints)
        {
            checkpoint.GetComponent<SpriteRenderer>().sprite = notActivated;
        }

            this.GetComponent<SpriteRenderer>().sprite = isActivated;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
