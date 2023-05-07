using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crank : MonoBehaviour
{
    public GameObject nextLevelGoer1;
    public GameObject nextLevelGoer2;
    public GameObject nextLevelGoer3;
    public bool canUp = false;
    public Sprite activated;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.R) && canUp == true)
        {
            nextLevelGoer1.SetActive(true);
            nextLevelGoer2.SetActive(true);
            nextLevelGoer3.SetActive(true);
            this.GetComponent<SpriteRenderer>().sprite = activated;
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
