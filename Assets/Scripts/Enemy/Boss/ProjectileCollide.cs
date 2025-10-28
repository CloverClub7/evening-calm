using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Projectiles that the boss can shoot
public class ProjectileCollide : MonoBehaviour
{
    public float damage = 3f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerProperties>().PlayerHurt(damage);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
