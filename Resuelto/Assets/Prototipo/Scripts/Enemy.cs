using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int health = 100;
    public float speed ;
    public GameObject deathEffect;
    public int enemyDamage;
    private Coroutine dañoCorrutina;
    public float espera = 3f;
    //public Rigidbody2D rbenemy;
    // Start is called before the first frame update
    private void Start()
    {

    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <=0)
        {
            Die();
        }
    }
    void Die ()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(effect, 4f);
    }

    // Update is called once per frame
    /*void Update()
    {

        MoverPrefabs();
    }
    void MoverPrefabs()
    {
        transform.position = Vector2.MoveTowards(transform.position,playerPos.position,speed * Time.deltaTime);

    }

   private void OnCollisionEnter2D(Collider2D collision)
   {
       Debug.Log("asdasdas");
       PlayerMovement player = collision.GetComponent<PlayerMovement>();
       if (player!= null)
       {
           player.PlayerTakeDamage(enemyDamage);
       }
   }
   private void OnTriggerEnter2D(Collider2D collision)
   {

       PlayerMovement player = collision.GetComponent<PlayerMovement>();
       if (player != null)
       {
           player.PlayerTakeDamage(enemyDamage);
       }
   }*/
    private void OnTriggerStay2D(Collider2D collision)
     {
         PlayerMovement player = collision.GetComponent<PlayerMovement>();
         if (player != null)
         {
            if (dañoCorrutina == null)
            {
                dañoCorrutina = StartCoroutine(DoDamage(player));
            }

            
         }
    }
    IEnumerator DoDamage(PlayerMovement player)
    {
        player.PlayerTakeDamage(enemyDamage);
        yield return new WaitForSeconds(espera);
        dañoCorrutina = null;
    }
    
}
