using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCharacter : MonoBehaviour
{
    [SerializeField] private float speed = 0.8f;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (PressKeyMove())
        {
            if (PressKeyMoveLeft())
            {
                GetComponent<Animator>().Play("Run");
                GetComponent<SpriteRenderer>().flipX = true;
                if (pos.x >= -8)
                    pos.x -= speed;
            }
            else if (PressKeyMoveRight())
            {
                GetComponent<Animator>().Play("Run");
                GetComponent<SpriteRenderer>().flipX = false;
                pos.x += speed;
            }
                
        }
        else GetComponent<Animator>().Play("Blink");
        transform.position = pos;
    }

    private bool PressKeyMove()
    {
        return PressKeyMoveLeft() || PressKeyMoveRight();
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
