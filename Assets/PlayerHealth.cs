using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health; 
    public int maxHealth = 10;
    
    void Start()
    {
        health = maxHealth;//start with max health
    }

    public void TakeDamage(int amount)
    {
        health -= amount; //amount,referenced in anither script = the damage of the damaging prefab
        if (health <= 0)// if health reaches 0, destroy the player object
        {
            Destroy(gameObject);
        }
    }
    
}
