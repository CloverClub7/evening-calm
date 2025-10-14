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
    private float momentumX = 0f;

    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

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
        if (IsGrounded())
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(momentumX + horizontal * speed * 0.5f, rb.velocity.y);
        }
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
    }

    private void Swim()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower * 0.25f);
            momentumX = rb.velocity.x / 3;
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            momentumX = rb.velocity.x / 3;
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower * 0.5f);
            momentumX = rb.velocity.x / 2;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            momentumX = rb.velocity.x / 2;
        }

        if (rb.velocity.x > 0 && horizontal < 0 || rb.velocity.x < 0 && horizontal > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x + horizontal * 0.5f, rb.velocity.y);
            momentumX = horizontal * 0.5f;
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
            rb.gravityScale /= 2;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 4)
        {
            isInWater = false;
            rb.gravityScale *= 2;
        }
    }
}