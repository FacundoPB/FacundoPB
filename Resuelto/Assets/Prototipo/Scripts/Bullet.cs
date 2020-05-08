using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public int damage = 40;

    private void Update()
    {
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy!=null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(effect, 0.2f);
        Destroy(gameObject);
    }

}
