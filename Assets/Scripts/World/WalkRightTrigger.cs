using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkRightTrigger : MonoBehaviour
{
    private bool isWalking = false;
    float timer = 0f;
    float delayBeforeEnd = 5f;
    Rigidbody2D playerRb;
    void OnTriggerEnter2D(Collider2D collide)
    {
        GameObject collidedWith = collide.gameObject;
        if (collidedWith.CompareTag("Player"))
        {
            isWalking = true;
            playerRb = collidedWith.GetComponent<Rigidbody2D>();
            Destroy(collidedWith.GetComponent<PlayerMovement>());
        }
    }

    void FixedUpdate()
    {
        if (isWalking)
        {
            playerRb.velocity = new Vector2(4, playerRb.velocity.y);
            timer += Time.deltaTime;
        }

        if (timer > delayBeforeEnd)
        {
            // END GAME
            Debug.Log("END OF GAME");
        }
    }
}
