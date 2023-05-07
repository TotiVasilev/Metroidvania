using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revealer : MonoBehaviour
{
    [Header("To Activate")]

    public GameObject fowA1;
    public GameObject fowA2;
    public GameObject fowA3;
    public GameObject fowA4;
    public GameObject fowA5;
    public GameObject fowA6;

    [Header("To Dectivate")]

    public GameObject fowDA1;
    public GameObject fowDA2;
    public GameObject fowDA3;
    public GameObject fowDA4;
    public GameObject fowDA5;
    public GameObject fowDA6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<CheckpointController>();
        if(player!=null)
        {
            if(fowA1 != null)
            {
                //fowA1.GetComponent<Animator>().SetTrigger("ac");
                fowA1.SetActive(true);
            }

            if(fowA2 != null)
            {
               // fowA2.GetComponent<Animator>().SetTrigger("ac");
                fowA2.SetActive(true);
            }

            if(fowA3 != null)
            {
                //fowA3.GetComponent<Animator>().SetTrigger("ac");
                fowA3.SetActive(true);
            }

            if(fowA4 != null)
            {
               // fowA4.GetComponent<Animator>().SetTrigger("ac");
                fowA4.SetActive(true);
            }

            if(fowA5 != null)
            {
               // fowA5.GetComponent<Animator>().SetTrigger("ac");
                fowA5.SetActive(true);
            }

            if(fowA6 != null)
            {
               // fowA6.GetComponent<Animator>().SetTrigger("ac");
                fowA6.SetActive(true);
            }

            if(fowDA1 != null)
            {
                //fowDA1.GetComponent<Animator>().SetTrigger("deac");
                fowDA1.SetActive(false);
            }

            if(fowDA2 != null)
            {
                //fowDA2.GetComponent<Animator>().SetTrigger("deac");
                fowDA2.SetActive(false);
            }

            if(fowDA3 != null)
            {
                //fowDA3.GetComponent<Animator>().SetTrigger("deac");
                fowDA3.SetActive(false);
            }

            if(fowDA4 != null)
            {
                //fowDA4.GetComponent<Animator>().SetTrigger("deac");
                fowDA4.SetActive(false);
            }

            if(fowDA5 != null)
            {
                //fowDA5.GetComponent<Animator>().SetTrigger("deac");
                fowDA5.SetActive(false);
            }

            if(fowDA6 != null)
            {
                //fowDA6.GetComponent<Animator>().SetTrigger("deac");
                fowDA6.SetActive(false);
            }
        }
    }


}
