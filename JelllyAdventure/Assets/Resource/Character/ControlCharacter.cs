using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCharacter : MonoBehaviour
{
    [SerializeField] private float speed = 0.8f;
    Vector3 pos;
    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        if (PressKeyMove())
        {
            if (PressKeyMoveLeft())
            {
                GetComponent<Animator>().Play("Run");
                GetComponent<SpriteRenderer>().flipX = true;
                if (pos.x >= -8)
                {
                    rigidbody.AddForce(new Vector2(-speed, 0));
                }
            }
            else if (PressKeyMoveRight())
            {
                GetComponent<Animator>().Play("Run");
                GetComponent<SpriteRenderer>().flipX = false;
                rigidbody.AddForce(new Vector2(speed, 0));
            }
        }
        else GetComponent<Animator>().Play("Blink");
        //transform.position = pos;
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
