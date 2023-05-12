using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;

    public float speed, jumpForce;
    public Transform groundCheck;
    public LayerMask ground;
    
    public bool isGround, isJump;

    bool jumpPressed;
    int jumpCount;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpPressed = true;
        }
    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
        GroundMovement();
        Jump();
    }

    void GroundMovement ()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
        anim.SetFloat("walk", Mathf.Abs(horizontalMove));

        if (horizontalMove != 0)
        {
            transform.localScale = new Vector3(horizontalMove*5, 5, 1);
        }
    }

    void Jump()
    {
        if (isGround)
        {
            jumpCount = 2;
            isJump = false;
        }
        if (jumpPressed)
            {
                isJump = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpCount--;
                jumpPressed = false;
            }
        else if (jumpPressed && jumpCount > 0 && isJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpCount--;
                jumpPressed = false;
            }
        }
    }

