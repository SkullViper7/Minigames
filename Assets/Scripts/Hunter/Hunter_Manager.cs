using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Hunter_Manager : MonoBehaviour
{
    private static Hunter_Manager _instance;

    public int players;
    public int score;
    public int round;
    public int maxRound;
    public int player1Pos;
    public int player2Pos;
    public int player3Pos;

    GameObject spotN;
    GameObject spotW;
    GameObject spotE;

    public Hunter_Manager Instance
    { 
        get 
        { 
            if (_instance == null)
            {
                Debug.LogError("Hunter Manager missing");
            }
            return _instance; 
        } 
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        if (players == 2)
        {
            maxRound = 2;
        }
        if (players == 3)
        {
            maxRound = 3;
        }
        if (players == 4)
        {
            maxRound = 4;
        }

        spotN = GameObject.Find("SpotN");
        spotW = GameObject.Find("SpotW");
        spotE = GameObject.Find("SpotE");
    }

    public void RoundBegin()
    {
        
    }
}