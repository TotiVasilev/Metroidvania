using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Needed if using canvas
public class HPDisplay : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public Sprite emptyHearth;
    public Sprite fullHealth;
    public Image[] hearts;

    public PlayerHealth playerHealth;//reference for the player's health variable
    
 
    
    void Update()
    {
        //Use for loop 
        //Depending on our health variable, change the UI that displays our HP
        health = playerHealth.health;
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHealth;
            }
            else
            {
                hearts[i].sprite = emptyHearth;
            }
            if(i < maxHealth) 
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
