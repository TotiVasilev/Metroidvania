using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public GameObject Player;
    public PlayerHealth playerHealth;//reference to the PlayerHealth script
    public int damage = 1;// damage per hit
    void Start()
    {
        playerHealth = Player.GetComponent<PlayerHealth>();
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)//collision with our Player
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.name == "Player")
        {
            if(collisionGameObject.GetComponent<PlayerHealth>() != null)
            {
                collisionGameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
                Destroy(gameObject);
            }
            playerHealth.TakeDamage(damage);//PlayerHealth script/TakeDamage function/ substract 1 hp per hit
        }
    }
}
