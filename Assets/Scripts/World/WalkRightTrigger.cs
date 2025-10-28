using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// At the end of the game, have the player walk all the way right of screen and end
public class WalkRightTrigger : MonoBehaviour
{
    private bool isWalking = false;
    float timer = 0f;
    float delayBeforeEnd = 3f;
    Rigidbody2D playerRb;
    PlayerProperties playerProperties;
    void OnTriggerEnter2D(Collider2D collide)
    {
        GameObject collidedWith = collide.gameObject;
        if (collidedWith.CompareTag("Player"))
        {
            isWalking = true;
            playerRb = collidedWith.GetComponent<Rigidbody2D>();
            playerProperties = collidedWith.GetComponent<PlayerProperties>();
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
            playerProperties.playerDie("Completed the game! Close the text box to play again",
                                       "Success!");
        }
    }
}
