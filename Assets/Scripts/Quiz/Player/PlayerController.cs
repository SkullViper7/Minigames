using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Inputs")]
    public InputActionReference answerOne;
    public InputActionReference answerTwo;
    public InputActionReference answerThree;
    public InputActionReference answerFour;
    InputAction input = null;

    [Header("Answers")]
    public int answerChosed;

    private void Awake()
    {
        input = new InputAction();
    }

    private void OnEnable()
    {
        input.Enable();
        answerOne.action.performed += AnswerOneChoose;
        answerTwo.action.performed += AnswerTwoChoose;
        answerThree.action.performed += AnswerThreeChoose;
        answerFour.action.performed += AnswerFourChoose;
    }

    private void OnDisable()
    {
        input.Disable();
        answerOne.action.performed -= AnswerOneChoose;
        answerTwo.action.performed -= AnswerTwoChoose;
        answerThree.action.performed -= AnswerThreeChoose;
        answerFour.action.performed -= AnswerFourChoose;
    }

    void AnswerOneChoose(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            answerChosed = 1;
        }
    }
    void AnswerTwoChoose(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            answerChosed = 2;
        }
    }
    void AnswerThreeChoose(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            answerChosed = 3;
        }
    }
    void AnswerFourChoose(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            answerChosed = 4;
        }
    }
}