using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Space]
    public PlayerInput playerInput;
    public LogoMove logoMove;

    [Header("Answers")]
    public int answerChosed;

    private void Start()
    {
        LinkPlayerToDevice();
    }

    private void LinkPlayerToDevice()
    {
        //If controller chosen is gamepad
        if (!GameManager.Instance.isOnKeyboard)
        {
            //Determine which PlayerInputControl to find depending of the name of the player
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
        //If controller chosen is keyboard
        else
        {
            //Active player one and two by default and player three and four if necessary
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
            //Find the player input control
            playerInput = GameObject.Find("PlayerInputControlKeyboard").GetComponent<PlayerInput>();
        }
    }

    private void TryToFindController(string _name)
    {
        //Try to find the PlayerInputControl for this player, if there is no PlayerInputControl for it, desactive it
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

        if (gameObject.tag == "Player1")
        {
            StartCoroutine(logoMove.Move(logoMove.player1, logoMove.AHolder1));
        }
        if (gameObject.tag == "Player2")
        {
            StartCoroutine(logoMove.Move(logoMove.player2, logoMove.AHolder2));
        }
        if (gameObject.tag == "Player3")
        {
            StartCoroutine(logoMove.Move(logoMove.player3, logoMove.AHolder3));
        }
        if (gameObject.tag == "Player4")
        {
            StartCoroutine(logoMove.Move(logoMove.player4, logoMove.AHolder4));
        }
    }

    void AnswerTwoChoose()
    {
        answerChosed = 2;

        if (gameObject.tag == "Player1")
        {
            StartCoroutine(logoMove.Move(logoMove.player1, logoMove.BHolder1));
        }
        if (gameObject.tag == "Player2")
        {
            StartCoroutine(logoMove.Move(logoMove.player2, logoMove.BHolder2));
        }
        if (gameObject.tag == "Player3")
        {
            StartCoroutine(logoMove.Move(logoMove.player3, logoMove.BHolder3));
        }
        if (gameObject.tag == "Player4")
        {
            StartCoroutine(logoMove.Move(logoMove.player4, logoMove.BHolder4));
        }
    }

    void AnswerThreeChoose()
    {
        answerChosed = 3;

        if (gameObject.tag == "Player1")
        {
            StartCoroutine(logoMove.Move(logoMove.player1, logoMove.XHolder1));
        }
        if (gameObject.tag == "Player2")
        {
            StartCoroutine(logoMove.Move(logoMove.player2, logoMove.XHolder2));
        }
        if (gameObject.tag == "Player3")
        {
            StartCoroutine(logoMove.Move(logoMove.player3, logoMove.XHolder3));
        }
        if (gameObject.tag == "Player4")
        {
            StartCoroutine(logoMove.Move(logoMove.player4, logoMove.XHolder4));
        }
    }

    void AnswerFourChoose()
    {
        answerChosed = 4;

        if (gameObject.tag == "Player1")
        {
            StartCoroutine(logoMove.Move(logoMove.player1, logoMove.YHolder1));
        }
        if (gameObject.tag == "Player2")
        {
            StartCoroutine(logoMove.Move(logoMove.player2, logoMove.YHolder2));
        }
        if (gameObject.tag == "Player3")
        {
            StartCoroutine(logoMove.Move(logoMove.player3, logoMove.YHolder3));
        }
        if (gameObject.tag == "Player4")
        {
            StartCoroutine(logoMove.Move(logoMove.player4, logoMove.YHolder4));
        }
    }
}