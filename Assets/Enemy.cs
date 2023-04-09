using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy instanceE;
    public int maxHealth = 100;
    private int currentHealth;

    private void Awake()
    {
        instanceE = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //play animation

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died");
        //die animation
        
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }
}
