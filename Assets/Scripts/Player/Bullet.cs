using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    Rigidbody2D playerRb;
    bool direction;
    float speed = 8f;
    float velo;
    float limit = 16f;
    float startPositionX;
    float damage = 3f;
    public float level = 1f;

    // Set direction of movement for a created bullet
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        GameObject player = GameObject.FindWithTag("Player");
        PlayerMovement playerMove = player.GetComponent<PlayerMovement>();
        direction = playerMove.isFacingRight;
        startPositionX = transform.position.x;

        if (direction)
        {
            velo = speed;
        }
        else
        {
            velo = -speed;
        }

        rb.velocity = new Vector2(velo, rb.velocity.y);
    }

    void Update()
    {
        // Delete the bullet after a certain distance
        if (transform.position.x > startPositionX + limit || transform.position.x < startPositionX - limit)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedWith = collision.gameObject;

        // If the bullet hits an enemy take damage
        if (collidedWith.CompareTag("Enemy"))
        {
            EnemyClass enemy = collidedWith.GetComponent<EnemyClass>();
            enemy.Damage(damage);
        }

        // Bullet despawns after colliding with anything except for the player
        if (!collidedWith.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
