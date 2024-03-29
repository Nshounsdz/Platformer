using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    int coinScore = 0;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void MyMethod()
    {
        //Debug.Log("oue");
    }

    public void GetCoin()
    {
        coinScore++;
        //Debug.Log(coinScore);
    }
}