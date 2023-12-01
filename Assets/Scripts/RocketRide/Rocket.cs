using System.Collections;
using System.Collections.Generic;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rocket : MonoBehaviour
{
    public float propulsion;

    private Vector2 lastOrientation;
    private Vector2 actualOrientation;

    new Rigidbody rigidbody;

    //GetComponent<PlayerInput>().onActionTriggered += OnAction;

    void Start()
    {
        lastOrientation = transform.up;
        actualOrientation = transform.up;

        rigidbody = GetComponent<Rigidbody>();
    }

    public void OrientationGamepad(InputValue _value)
    {
        lastOrientation = actualOrientation;

        //If joystick is not in neutral pos, actual orientation is the same as the joystick
        if (_value.Get<Vector2>() != new Vector2(0, 0))
        {
            actualOrientation = _value.Get<Vector2>();
        }
        //Else keep the last orientation to not go to the neutral pos
        else
        {
            actualOrientation = lastOrientation;
        }

        //Rocket orientation is the same as the stick
        transform.up = new Vector2(actualOrientation.x, Mathf.Clamp(actualOrientation.y, 0f, 1f));
    }

    public void PropulsionGamepad()
    {
        //Rocket moves
        rigidbody.AddForce(transform.up * propulsion);
    }
}
