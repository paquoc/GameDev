using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enimies : MonoBehaviour
{

    public ControlCharacter player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ControlCharacter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.Death();
        }
    }
}
