using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject Ebanemi;

    public bool kuramiqnko = false;

    public bool shesagrumnaskoro = false;
    public Vector3 Pos = new Vector3(67, 12, 0);
    
    public GameObject Doorr;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(kuramiqnko == true && shesagrumnaskoro == false)
        {
            StartCoroutine(SpawnEbanemi());
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<CheckpointController>();
        if(player!=null)
        {
            if(kuramiqnko == false)
            {
                Doorr.SetActive(true);
                //Destroy(gameObject);
                kuramiqnko = true;
            }
          
            


        }
    }

    public IEnumerator SpawnEbanemi()
    {
        shesagrumnaskoro = true;
        yield return new WaitForSeconds(4f);
        Instantiate( Ebanemi, Pos, Quaternion.identity);
        //Instantiate(Ebanemi, transform.position, Quaternion.identity);
        //shesagrumnaskoro = false;
    }
}
