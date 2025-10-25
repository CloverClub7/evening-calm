using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float limit = 6f;    // Limit distance of bullet
    private float damage = 3f;   // How much damage the bullet deals
    private float speed = 11f;  // Speed of the bullet
    private float velocity;     // Velocity of the bullet
    private float startPositionX;   // The starting position of the bullet
    private PlayerProperties playerProperties; // Pull data from here
    // Set direction of movement for a created bullet
    void Start()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();

        GameObject player = GameObject.FindWithTag("Player");
        PlayerMovement playerMove = player.GetComponent<PlayerMovement>();
        PlayerProperties playerProperties = player.GetComponent<PlayerProperties>();

        limit = limit * playerProperties.pistolRangeMultiplier;
        damage = damage * playerProperties.pistolRangeMultiplier;

        bool isTravellingRight = playerMove.isFacingRight;

        startPositionX = transform.position.x;

        if (isTravellingRight)
        {
            velocity = speed;
        }
        else
        {
            velocity = -speed;
        }

        rb.velocity = new Vector2(velocity, rb.velocity.y);
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

        // If the bullet hits a breakable block
        if (collidedWith.CompareTag("BreakableBlock"))
        {
            BreakableBlock block = collidedWith.GetComponent<BreakableBlock>();
            block.Damage(damage);
        }

        // Bullet despawns after colliding with anything except for the player
        if (!collidedWith.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
