using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton
    private static GameManager _instance = null;
    public static GameManager Instance => _instance;
    //

    public string game = "";

    public bool isOnKeyboard;

    public int maxPlayerCount;
    public int playerCount;

    private void Awake()
    {
        //Singleton
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
        }
        //

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        playerCount = 0;
    }
}
