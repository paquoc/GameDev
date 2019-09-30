using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCharacter : MonoBehaviour
{
    public float speed = 50f;
    public float jumpForce = 100f;
    Vector3 pos;
    Rigidbody2D rigidBody;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator.SetBool("isAlive", true);
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        if (PressKeyMove())
        {
            if (PressKeyMoveLeft())
            {
                animator.Play("Run");
                GetComponent<SpriteRenderer>().flipX = true;
                rigidBody.AddForce(new Vector2(-speed, 0));
            }
            else if (PressKeyMoveRight())
            {
                animator.Play("Run");
                GetComponent<SpriteRenderer>().flipX = false;
                rigidBody.AddForce(new Vector2(speed, 0));
            }
            else if (PressKeyMoveUp())
            {
                Jump();
            }
            //animator.SetBool("isGrounded", IsGrounded());
        }
        else GetComponent<Animator>().Play("Blink");
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            //rigidBody.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
            rigidBody.AddForce(new Vector2(0, jumpForce));
        }
    }

    public LayerMask groundLayer;
    private bool IsGrounded()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.8f, groundLayer.value))
            return true;
        return false;
    }

    private bool PressKeyMoveUp()
    {
        return Input.GetKey(KeyCode.UpArrow);
    }

    private bool PressKeyMove()
    {
        return PressKeyMoveLeft() || PressKeyMoveRight() || PressKeyMoveUp();
    }

    private bool PressKeyMoveRight()
    {
        return Input.GetKey(KeyCode.RightArrow);
    }

    private bool PressKeyMoveLeft()
    {
        return Input.GetKey(KeyCode.LeftArrow);
    }
}
