using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCharacter : MonoBehaviour
{
    [SerializeField] private float speed = 1;
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
                //GetComponent<Animator>().SetBool("Run", true);
                GetComponent<SpriteRenderer>().flipX = true;
                pos.x -= speed;
            }
            else if (PressKeyMoveRight())
            {
                GetComponent<SpriteRenderer>().flipX = false;
                pos.x += speed;
            }
                
        }
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
