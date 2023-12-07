using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BlocPlayer_Input : MonoBehaviour
{
    private InputActions _inputActions;
    private PlayerInput _playerInput;
    public Camera _camera;
    private bool isSpawning = false;

    public GameObject cubeToSpawn;

    private void Start()
    {
        LinkPlayerToDevice();
    }

    private void Spawner()
    {
        isSpawning = true;
        Instantiate(cubeToSpawn, transform.position, transform.rotation);
        transform.position += new Vector3(0f, 0.5f, 0f);
        BlocUI_Manager.Instance.scoresPlayers[gameObject.name]++;
        isSpawning = false;
    }

    public void OnAction(InputAction.CallbackContext context)
    {
        if (!BTBloc_Manager.Instance.isGameOver && !isSpawning)
        {
            switch (context.action.name)
            {
                case "Direction_North":
                    if (!GameManager.Instance.isOnKeyboard)
                    {
                        if (context.started == true)
                        {
                            Spawner();
                        }
                    }
                    break;

                case "J1_North":
                    if (gameObject.CompareTag("Player1"))
                    {
                        if (context.started == true)
                        {
                            Spawner();
                        }
                    }
                    break;
                case "J2_North":
                    if (gameObject.CompareTag("Player2"))
                    {
                        if (context.started == true)
                        {
                            Spawner();
                        }
                    }
                    break;
                case "J3_North":
                    if (gameObject.CompareTag("Player3"))
                    {
                        if (context.started == true)
                        {
                            Spawner();
                        }
                    }
                    break;
                case "J4_North":
                    if (gameObject.CompareTag("Player4"))
                    {
                        if (context.started == true)
                        {
                            Spawner();
                        }
                    }
                    break;
            }
        }
    }


    private void LinkPlayerToDevice()
    {
        //If controller chosen is gamepad
        if (!GameManager.Instance.isOnKeyboard)
        {
            //Determine which PlayerInputControl to find depending of the name of the player
            switch (gameObject.name)
            {
                case "Bloc_Player_1":
                    TryToFindController("PlayerInputControl1");
                    break;
                case "Bloc_Player_2":
                    TryToFindController("PlayerInputControl2");
                    break;
                case "Bloc_Player_3":
                    TryToFindController("PlayerInputControl3");
                    break;
                case "Bloc_Player_4":
                    TryToFindController("PlayerInputControl4");
                    break;
            }
        }
        //If controller chosen is keyboard
        else
        {
            //Active player 1 and 2 by default and 3 and 4 if necessary
            switch (gameObject.name)
            {
                case "Bloc_Player_1":
                    gameObject.SetActive(true);
                    BlocUI_Manager.Instance.scoresPlayers.Add(gameObject.name, 0);
                    break;
                case "Bloc_Player_2":
                    gameObject.SetActive(true);
                    BlocUI_Manager.Instance.scoresPlayers.Add(gameObject.name, 0);
                    break;
                case "Bloc_Player_3":
                    if (GameManager.Instance.maxPlayerCount >= 3)
                    {
                        gameObject.SetActive(true);
                        BlocUI_Manager.Instance.scoresPlayers.Add(gameObject.name, 0);
                    }
                    else
                    {
                        gameObject.SetActive(false);
                    }
                    break;
                case "Bloc_Player_4":
                    if (GameManager.Instance.maxPlayerCount == 4)
                    {
                        gameObject.SetActive(true);
                        BlocUI_Manager.Instance.scoresPlayers.Add(gameObject.name, 0);
                    }
                    else
                    {
                        gameObject.SetActive(false);
                    }
                    break;
            }
            //Find the player input control
            _playerInput = GameObject.Find("PlayerInputControlKeyboard").GetComponent<PlayerInput>();
            _playerInput.onActionTriggered += OnAction;
        }
    }

    private void TryToFindController(string _name)
    {
        //Try to find the PlayerInputControl for this player, if there is no PlayerInputControl for it, desactive it
        if (GameObject.Find(_name) != null)
        {
            _playerInput = GameObject.Find(_name).GetComponent<PlayerInput>();
            _playerInput.camera = _camera;
            _playerInput.onActionTriggered += OnAction;
            BlocUI_Manager.Instance.scoresPlayers.Add(gameObject.name, 0);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
