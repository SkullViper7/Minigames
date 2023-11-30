using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1_Input : MonoBehaviour
{
    private InputActions _inputActions;

    private void Awake()
    {
        _inputActions = new InputActions();
    }

    private void OnEnable()
    {
        _inputActions.Hunter.Direction_North.Enable();
        _inputActions.Hunter.Direction_West.Enable();
        _inputActions.Hunter.Direction_East.Enable();

        _inputActions.Hunter.J1_North.Enable();
        _inputActions.Hunter.J1_West.Enable();
        _inputActions.Hunter.J1_East.Enable();

        _inputActions.Hunter.J2_North.Enable();
        _inputActions.Hunter.J2_West.Enable();
        _inputActions.Hunter.J2_East.Enable();

        _inputActions.Hunter.J3_North.Enable();
        _inputActions.Hunter.J3_West.Enable();
        _inputActions.Hunter.J3_East.Enable();

        _inputActions.Hunter.J4_North.Enable();
        _inputActions.Hunter.J4_West.Enable();
        _inputActions.Hunter.J4_East.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Hunter.Direction_North.Disable();
        _inputActions.Hunter.Direction_West.Disable();
        _inputActions.Hunter.Direction_East.Disable();

        _inputActions.Hunter.J1_North.Disable();
        _inputActions.Hunter.J1_West.Disable();
        _inputActions.Hunter.J1_East.Disable();

        _inputActions.Hunter.J2_North.Disable();
        _inputActions.Hunter.J2_West.Disable();
        _inputActions.Hunter.J2_East.Disable();

        _inputActions.Hunter.J3_North.Disable();
        _inputActions.Hunter.J3_West.Disable();
        _inputActions.Hunter.J3_East.Disable();

        _inputActions.Hunter.J4_North.Disable();
        _inputActions.Hunter.J4_West.Disable();
        _inputActions.Hunter.J4_East.Disable();
    }
}
