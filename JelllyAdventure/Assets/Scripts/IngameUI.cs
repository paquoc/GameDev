using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUI : MonoBehaviour
{
    public Text labelNumCoin;
    public static IngameUI instance { get; private set; }

    private void Awake()
    {
        instance = this;
        labelNumCoin.text = testGameData.instance.GetScore().ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateLabelNumCoin()
    {
        int numCoin = UserInfo.instance.getScore();
        labelNumCoin.text = numCoin.ToString();
    }
}
