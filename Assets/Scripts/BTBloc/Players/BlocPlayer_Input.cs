using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BlocPlayer_Input : MonoBehaviour
{
    private InputActions _inputActions;
    BTBloc_Manager blocManager;

    public GameObject cubeToSpawn;

    private void Awake()
    {
        _inputActions = new InputActions();
        blocManager = GameObject.Find("Game Manager").GetComponent<BTBloc_Manager>();
    }

    private void OnEnable()
    {
        _inputActions.Hunter.Direction_North.performed += OnNorth;
        _inputActions.Hunter.Direction_North.Enable();

        if (gameObject.tag == "Player1")
        {
            _inputActions.Hunter.J1_North.performed += OnNorth;
            _inputActions.Hunter.J1_North.Enable();
        }

        if (gameObject.tag == "Player2")
        {
            _inputActions.Hunter.J2_North.performed += OnNorth;
            _inputActions.Hunter.J2_North.Enable();
        }

        if (gameObject.tag == "Player3")
        {
            _inputActions.Hunter.J3_North.performed += OnNorth;
            _inputActions.Hunter.J3_North.Enable();
        }

        if (gameObject.tag == "Player4")
        {
            _inputActions.Hunter.J4_North.performed += OnNorth;
            _inputActions.Hunter.J4_North.Enable();
        }
    }

    private void OnNorth(InputAction.CallbackContext context)
    {
        if (gameObject.tag == "Player1")
        {
            blocManager.player1Score++;
            Instantiate(cubeToSpawn, transform.position, transform.rotation);
            transform.position += new Vector3(0f, 0.5f, 0f);
        }

        if (gameObject.tag == "Player2")
        {
            blocManager.player2Score++;
            Instantiate(cubeToSpawn, transform.position, transform.rotation);
            transform.position += new Vector3(0f, 0.5f, 0f);
        }

        if (gameObject.tag == "Player3")
        {
            blocManager.player3Score++;
            Instantiate(cubeToSpawn, transform.position, transform.rotation);
            transform.position += new Vector3(0f, 0.5f, 0f);
        }

        if (gameObject.tag == "Player4")
        {
            blocManager.player4Score++;
            Instantiate(cubeToSpawn, transform.position, transform.rotation);
            transform.position += new Vector3(0f, 0.5f, 0f);
        }
    }

    private void OnDisable()
    {
        _inputActions.Hunter.Direction_North.performed -= OnNorth;
        _inputActions.Hunter.Direction_North.Disable();

        _inputActions.Hunter.J1_North.performed -= OnNorth;
        _inputActions.Hunter.J1_North.Disable();

        _inputActions.Hunter.J2_North.performed -= OnNorth;
        _inputActions.Hunter.J2_North.Disable();

        _inputActions.Hunter.J3_North.performed -= OnNorth;
        _inputActions.Hunter.J3_North.Disable();

        _inputActions.Hunter.J4_North.performed -= OnNorth;
        _inputActions.Hunter.J4_North.Disable();
    }
}
