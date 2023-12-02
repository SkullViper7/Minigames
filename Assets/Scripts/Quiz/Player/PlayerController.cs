using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Space]
    public PlayerInput playerInput;

    [Header("Answers")]
    public int answerChosed;

    private void Start()
    {
        LinkPlayerToDevice();
    }

    private void LinkPlayerToDevice()
    {
        if (!GameManager.Instance.isOnKeyboard)
        {
            //Determine which PlayerInputControl to find depending of the name of the rocket
            switch (gameObject.name)
            {
                case "Player1":
                    TryToFindController("PlayerInputControl1");
                    break;
                case "Player2":
                    TryToFindController("PlayerInputControl2");
                    break;
                case "Player3":
                    TryToFindController("PlayerInputControl3");
                    break;
                case "Player4":
                    TryToFindController("PlayerInputControl4");
                    break;
            }
        }

        else
        {
            switch (gameObject.name)
            {
                case "Player1":
                    gameObject.SetActive(true);

                    break;

                case "Player2":
                    gameObject.SetActive(true);
                    break;

                case "Player3":
                    if (GameManager.Instance.maxPlayerCount >= 3)
                    {
                        gameObject.SetActive(true);
                    }

                    else
                    {
                        gameObject.SetActive(false);
                    }
                    break;

                case "Player4":
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

        }
    }

    private void TryToFindController(string _name)
    {
        //Try to find the PlayerInputControl for this rocket, if there is no PlayerInputControl for it, desactive it
        if (GameObject.Find(_name) != null)
        {
            playerInput = GameObject.Find(_name).GetComponent<PlayerInput>();
            playerInput.onActionTriggered += OnAction;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void OnAction(InputAction.CallbackContext context)
    {
        switch (context.action.name)
        {
            case "Answer1":
                AnswerOneChoose();
                break;
            case "Answer2":
                AnswerTwoChoose();
                break;
            case "Answer3":
                AnswerThreeChoose();
                break;
            case "Answer4":
                AnswerFourChoose();
                break;
        }
    }

    void AnswerOneChoose()
    {
        answerChosed = 1;
    }

    void AnswerTwoChoose()
    {
        answerChosed = 2;
    }

    void AnswerThreeChoose()
    {
        answerChosed = 3;
    }

    void AnswerFourChoose()
    {
        answerChosed = 4;
    }
}