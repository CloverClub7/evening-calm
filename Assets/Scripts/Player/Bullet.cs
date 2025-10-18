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
}
