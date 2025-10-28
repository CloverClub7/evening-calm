using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 4f;
    private float jumpingPower = 14f;
    public bool isFacingRight = true;
    private bool isInWater = false;

    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private AudioClip jumpSound;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isInWater)
        {
            Swim();
        }
        else
        {
            Jump();
        }
        
        animator.SetBool("isJumping", !IsGrounded() && !isInWater);
        animator.SetBool("isInWater", isInWater);

        Flip();
    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (IsGrounded())
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(horizontal * speed * 0.7f, rb.velocity.y);
        }

        // Let the animator know the player is moving
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
    }

    private void Swim()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower * 0.33f);

            SoundFXManager.instance.PlaySoundClip(jumpSound, transform, 1f);
        }

        
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower * 0.5f);

            SoundFXManager.instance.PlaySoundClip(jumpSound, transform, 1f);
        }

        if (rb.velocity.x > 0 && horizontal < 0 || rb.velocity.x < 0 && horizontal > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x + horizontal * 0.5f, rb.velocity.y);
        }
    }

    // Flipping the direction the player faces
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    // Entering and exiting water
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 4)
        {
            isInWater = true;
            rb.gravityScale /= 5;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 4)
        {
            isInWater = false;
            rb.gravityScale *= 5;
        }
    }
}