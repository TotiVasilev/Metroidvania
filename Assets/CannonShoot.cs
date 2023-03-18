using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    public Transform firepoint;//spawn point of the prefab
    public GameObject bullet; //chosed a short name instead of cannonWaterBall or smth

    //time after the bullet has been spawned
    float timeBetween; 
    public float startTimeBetween;

    // Start is called before the first frame update
    void Start()
    {
        timeBetween = startTimeBetween;
    }

    // Update is called once per frame
    void Update()
    {
        //Instantiate the prefab when the timer <= 0
        if (timeBetween <= 0)
        {
            Instantiate(bullet,firepoint.position, firepoint.rotation);
            timeBetween = startTimeBetween;//restart the wait timer
        }
        else
        {
            timeBetween -= Time.deltaTime;//substract untill it reaches 0 spawn
        }
    }
}
