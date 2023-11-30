using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Input : MonoBehaviour
{
    private InputActions _inputActions;

    [SerializeField] GameObject spotN;
    GameObject spotW;
    GameObject spotE;

    private void Awake()
    {
        _inputActions = new InputActions();

        spotN = GameObject.Find("Spot N");
        spotW = GameObject.Find("Spot W");
        spotE = GameObject.Find("Spot E");
    }

    private void OnEnable()
    {
        _inputActions.Hunter.Direction_North.performed += OnNorth;
        _inputActions.Hunter.Direction_North.Enable();
        _inputActions.Hunter.Direction_West.performed += OnWest;
        _inputActions.Hunter.Direction_West.Enable();
        _inputActions.Hunter.Direction_East.performed += OnEast;
        _inputActions.Hunter.Direction_East.Enable();

        if (gameObject.tag == "Player1")
        {
            _inputActions.Hunter.J1_North.performed += OnNorth;
            _inputActions.Hunter.J1_North.Enable();
            _inputActions.Hunter.J1_West.performed += OnWest;
            _inputActions.Hunter.J1_West.Enable();
            _inputActions.Hunter.J1_East.performed += OnEast;
            _inputActions.Hunter.J1_East.Enable();
        }

        if (gameObject.tag == "Player2")
        {
            _inputActions.Hunter.J2_North.performed += OnNorth;
            _inputActions.Hunter.J2_North.Enable();
            _inputActions.Hunter.J2_West.performed += OnWest;
            _inputActions.Hunter.J2_West.Enable();
            _inputActions.Hunter.J2_East.performed += OnEast;
            _inputActions.Hunter.J2_East.Enable();
        }

        if (gameObject.tag == "Player3")
        {
            _inputActions.Hunter.J3_North.performed += OnNorth;
            _inputActions.Hunter.J3_North.Enable();
            _inputActions.Hunter.J3_West.performed += OnWest;
            _inputActions.Hunter.J3_West.Enable();
            _inputActions.Hunter.J3_East.performed += OnEast;
            _inputActions.Hunter.J3_East.Enable();
        }

        if (gameObject.tag == "Player4")
        {
            _inputActions.Hunter.J4_North.performed += OnNorth;
            _inputActions.Hunter.J4_North.Enable();
            _inputActions.Hunter.J4_West.performed += OnWest;
            _inputActions.Hunter.J4_West.Enable();
            _inputActions.Hunter.J4_East.performed += OnEast;
            _inputActions.Hunter.J4_East.Enable();
        }
    }

    private void OnNorth(InputAction.CallbackContext context)
    {
        if (gameObject.tag == "Player1")
        {
            spotN.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    private void OnWest(InputAction.CallbackContext context)
    {
        if (gameObject.tag == "Player1")
        {
            spotW.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    private void OnEast(InputAction.CallbackContext context)
    {
        if (gameObject.tag == "Player1")
        {
            spotE.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnDisable()
    {
        _inputActions.Hunter.Direction_North.performed -= OnNorth;
        _inputActions.Hunter.Direction_North.Disable();
        _inputActions.Hunter.Direction_West.performed -= OnWest;
        _inputActions.Hunter.Direction_West.Disable();
        _inputActions.Hunter.Direction_East.performed -= OnEast;
        _inputActions.Hunter.Direction_East.Disable();

        _inputActions.Hunter.J1_North.performed -= OnNorth;
        _inputActions.Hunter.J1_North.Disable();
        _inputActions.Hunter.J1_West.performed -= OnWest;
        _inputActions.Hunter.J1_West.Disable();
        _inputActions.Hunter.J1_East.performed -= OnEast;
        _inputActions.Hunter.J1_East.Disable();

        _inputActions.Hunter.J2_North.performed -= OnNorth;
        _inputActions.Hunter.J2_North.Disable();
        _inputActions.Hunter.J2_West.performed -= OnWest;
        _inputActions.Hunter.J2_West.Disable();
        _inputActions.Hunter.J2_East.performed -= OnEast;
        _inputActions.Hunter.J2_East.Disable();

        _inputActions.Hunter.J3_North.performed -= OnNorth;
        _inputActions.Hunter.J3_North.Disable();
        _inputActions.Hunter.J3_West.performed -= OnWest;
        _inputActions.Hunter.J3_West.Disable();
        _inputActions.Hunter.J3_East.performed -= OnEast;
        _inputActions.Hunter.J3_East.Disable();

        _inputActions.Hunter.J4_North.performed -= OnNorth;
        _inputActions.Hunter.J4_North.Disable();
        _inputActions.Hunter.J4_West.performed -= OnWest;
        _inputActions.Hunter.J4_West.Disable();
        _inputActions.Hunter.J4_East.performed -= OnEast;
        _inputActions.Hunter.J4_East.Disable();
    }
}
