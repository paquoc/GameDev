using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo:MonoBehaviour
{
    private int score = 0;
    private int live = 2;
    
    public static UserInfo instance { get; private set;}

    private void Awake()
    {
        instance = this;
    }

    public void addScore(int v)
    {
        this.score += v;
    }

    public int getScore()
    {
        return score;
    }
}
