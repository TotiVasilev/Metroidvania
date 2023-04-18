using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public bool lockkk;

    public int count = 0;
    public GameObject Dialgoue;
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;

    // Start is called before the first frame update
    void Start()
    {
        //lockkk = true;
        //StartCoroutine(Cooldown());
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetMouseButtonDown(0) && lockkk == false)
            {
                if(count==0)
                {
                    Text1.SetActive(false);
                    Text2.SetActive(true);
                    count++;
                    lockkk = true;
                    StartCoroutine(Cooldown());
                }
                else if( count==1)
                {  
                    Dialgoue.SetActive(false);
                    Destroy(gameObject);

                }

            }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<CheckpointController>();
        if(player!=null)
        {
            Dialgoue.SetActive(true);
            lockkk = true;
        StartCoroutine(Cooldown());
            


        }
    }

     private void OnTriggerExit2D(Collider2D other)
    {
        var player = other.GetComponent<CheckpointController>();
        if(player!=null)
        {
             Dialgoue.SetActive(false);
            Destroy(gameObject);
            
        
            


        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(2f);
        lockkk = false;

    }
}
