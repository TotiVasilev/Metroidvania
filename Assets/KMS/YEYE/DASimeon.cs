using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DASimeon : MonoBehaviour
{
    public GameObject DSimeon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Simeon")
        {
            this.GetComponent<Animator>().SetFloat("Running",0);
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            DSimeon.SetActive(true);
        }
    }
}
