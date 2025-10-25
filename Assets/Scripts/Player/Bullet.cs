using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Limit = 4f;    // Limit distance of bullet
    public float Damage = 3f;   // How much damage the bullet deals
    private float speed = 11f;  // Speed of the bullet
    private float velocity;     // Velocity of the bullet
    private float startPositionX;   // The starting position of the bullet

    // Set direction of movement for a created bullet
    void Start()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();

        GameObject player = GameObject.FindWithTag("Player");
        PlayerMovement playerMove = player.GetComponent<PlayerMovement>();

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
        if (transform.position.x > startPositionX + Limit || transform.position.x < startPositionX - Limit)
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
            enemy.Damage(Damage);
        }

        // If the bullet hits a breakable block
        if (collidedWith.CompareTag("BreakableBlock"))
        {
            BreakableBlock block = collidedWith.GetComponent<BreakableBlock>();
            block.Damage(Damage);
        }

        // Bullet despawns after colliding with anything except for the player
        if (!collidedWith.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
