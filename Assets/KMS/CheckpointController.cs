using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public HPplayer playerHP;
    public GameObject DeathScreen;
    public Vector2 startPos;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Death"))
        {
            Die();
        }
    }

    public void Die()
    {
        StartCoroutine(Respawn(0.5f));
    
    }
    public void Dead()
    {
        StartCoroutine(RespawnWhenDead(0.5f));
        StartCoroutine(LoadHP(1f));
    }

    IEnumerator Respawn(float duration)
    {
        spriteRenderer.enabled = false;
        Instantiate(DeathScreen);
        yield return new WaitForSeconds(duration);
        transform.position = startPos;
        spriteRenderer.enabled=true;
    }
    IEnumerator RespawnWhenDead(float durationD)
    {

        Instantiate(DeathScreen);
        yield return new WaitForSeconds(durationD);
        transform.position = startPos;
        
    }
    IEnumerator LoadHP(float after)
    {
        
        yield return new WaitForSeconds(after);

        playerHP.UpdateHP(40);
    }
}
