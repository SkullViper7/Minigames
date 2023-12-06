using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class BTBloc_Manager : MonoBehaviour
{

    public int players;
    public float setTimer;
    private float timer;
    private bool isTimerActive;
    public int player1Score;
    public int player2Score;
    public int player3Score;
    public int player4Score;

    //Singleton
    private static BTBloc_Manager _instance = null;
    private BTBloc_Manager() { }
    public static BTBloc_Manager Instance => _instance;
    //

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
                BlocUI_Manager.Instance.DisplayTime(timer);
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