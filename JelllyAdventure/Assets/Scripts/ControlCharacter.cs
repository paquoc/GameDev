using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCharacter : MonoBehaviour
{

    public float speed = 50f, maxSpeed = 3, jumpPow = 350f;
    public Rigidbody2D rigidBody;
    public Animator animator;
    public bool isGrounded = true;
    private bool faceright = true;
    private bool canDoubleJump = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Grounded", isGrounded);
        animator.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
        animator.SetFloat("SpeedUp", rigidBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded)
            {
                isGrounded = false;
                canDoubleJump = true;
                rigidBody.AddForce(Vector2.up * jumpPow);
            }
            else if (canDoubleJump)
            {
                isGrounded = false;
                canDoubleJump = false;
                rigidBody.AddForce(Vector2.up * jumpPow);
            }
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        rigidBody.AddForce((Vector2.right) * speed * h);

        if (rigidBody.velocity.x > maxSpeed)
            rigidBody.velocity = new Vector2(maxSpeed, rigidBody.velocity.y);
        if (rigidBody.velocity.x < -maxSpeed)
            rigidBody.velocity = new Vector2(-maxSpeed, rigidBody.velocity.y);

        if (h > 0 && !faceright)
            FlipX();
        if (h < 0 && faceright)
            FlipX();

        if (isGrounded)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x * 0.7f, rigidBody.velocity.y);
        }
    }

    private void FlipX()
    {
        faceright = !faceright;
        Vector3 scale;
        scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
