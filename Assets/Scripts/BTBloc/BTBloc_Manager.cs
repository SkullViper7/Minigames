using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class BTBloc_Manager : MonoBehaviour
{
    private static BTBloc_Manager _instance;
    private BlocUI_Manager _uiManager;

    public int players;
    public float setTimer;
    private float timer;
    private bool isTimerActive;
    public int player1Score;
    public int player2Score;
    public int player3Score;
    public int player4Score;

    public BTBloc_Manager Instance
    { 
        get 
        { 
            if (_instance == null)
            {
                Debug.LogError("Game Manager missing");
            }
            return _instance; 
        } 
    }

    private void Awake()
    {
        _instance = this;
        _uiManager = GameObject.Find("Canvas").GetComponent<BlocUI_Manager>();
    }

    private void Start()
    {
        timer = setTimer;
        isTimerActive = true;
    }

    private void FixedUpdate()
    {
        if (isTimerActive)
        {
            if (timer > 0)
            {
                timer = timer - Time.deltaTime;
                _uiManager.DisplayTime(timer);
            }
            else
            {
                timer = 0;
                isTimerActive = false;
                EndGame();
            }
        }
        
    }

        private void EndGame()
    {

    }
}