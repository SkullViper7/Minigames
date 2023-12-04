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

    public GameObject cubeToSpawn;

    private void Start()
    {
        LinkPlayerToDevice();
    }

    private void Spawner(string tag)
    {
        BTBloc_Manager.Instance.player1Score++;
        Instantiate(cubeToSpawn, transform.position, transform.rotation);
        transform.position += new Vector3(0f, 0.5f, 0f);
    }

    public void OnAction(InputAction.CallbackContext context)
    {
        switch (context.action.name)
        {
            case "Direction_North":
                Spawner(gameObject.tag);
                break;

            case "J1_North":
                if (gameObject.CompareTag("Player1"))
                {
                    Spawner(gameObject.tag);
                }
                break;
            case "J2_North":
                if (gameObject.CompareTag("Player2"))
                {
                    Spawner(gameObject.tag);
                }
                break;
            case "J3_North":
                if (gameObject.CompareTag("Player3"))
                {
                    Spawner(gameObject.tag);
                }
                break;
            case "J4_North":
                if (gameObject.CompareTag("Player4"))
                {
                    Spawner(gameObject.tag);
                }
                break;
        }
    }


    private void LinkPlayerToDevice()
    {
        //If controller chosen is gamepad
        if (!GameManager.Instance.isOnKeyboard)
        {
            //Determine which PlayerInputControl to find depending of the name of the rocket
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
            //Active green and red rocket by default and blue and yellow if necessary
            switch (gameObject.name)
            {
                case "Bloc_Player_1":
                    gameObject.SetActive(true);
                    break;
                case "Bloc_Player_2":
                    gameObject.SetActive(true);
                    break;
                case "Bloc_Player_3":
                    if (GameManager.Instance.maxPlayerCount >= 3)
                    {
                        gameObject.SetActive(true);
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
                    }
                    else
                    {
                        gameObject.SetActive(false);
                    }
                    break;
            }
            //Find the player input control
            _playerInput = GameObject.Find("PlayerInputControlKeyboard").GetComponent<PlayerInput>();
        }
    }

    private void TryToFindController(string _name)
    {
        //Try to find the PlayerInputControl for this rocket, if there is no PlayerInputControl for it, desactive it
        if (GameObject.Find(_name) != null)
        {
            _playerInput = GameObject.Find(_name).GetComponent<PlayerInput>();
            _playerInput.camera = _camera;
            _playerInput.onActionTriggered += OnAction;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
