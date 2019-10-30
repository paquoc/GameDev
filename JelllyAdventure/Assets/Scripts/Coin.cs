using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool exist = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (exist)
        {
            if (collision.CompareTag("Player"))
            {
                exist = false;
                UserInfo.instance.addScore(1);
                IngameUI.instance.UpdateLabelNumCoin();
                this.removeFromScene();
            }
        }
        
    }

    private void removeFromScene()
    {
        Destroy(this.gameObject);
    }
}
