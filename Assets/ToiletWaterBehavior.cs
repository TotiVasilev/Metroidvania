using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletWaterBehavior : MonoBehaviour
{
    
    public GameObject blockingWater;//Block prefab
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        //Collision with game object tagged Toilet will make the blocking prefab disappear
        if(other.gameObject.CompareTag("Toilet"))
        {
            blockingWater.SetActive(false);
        }
        
    }

    
}
