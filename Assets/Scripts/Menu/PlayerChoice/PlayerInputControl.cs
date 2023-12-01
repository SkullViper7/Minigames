using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputControl : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void OnAction(InputAction.CallbackContext context)
    {

    }

    //Quiz
    public void OnAnswer1()
    {

    }

    public void OnAnswer2()
    {

    }

    public void OnAnswer3()
    {

    }

    public void OnAnswer4()
    {
        
    }

    //RocketRide
    public void OnOrientationGamepad()
    {

    }

    public void OnPropulsionGamepad()
    {

    }

    //BTBloc
    public void OnNorth()
    {

    }

    //SlimeJump
}
