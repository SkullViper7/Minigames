using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    public float propulsion;

    private Vector2 lastOrientation;
    private Vector2 actualOrientation;

    Rigidbody rigidbody;

    void Start()
    {
        lastOrientation = transform.up;
        actualOrientation = transform.up;

        rigidbody = GetComponent<Rigidbody>();
    }

    public void OnOrientationGamepad(InputValue _value)
    {
        lastOrientation = actualOrientation;

        if (_value.Get<Vector2>() != new Vector2(0, 0))
        {
            actualOrientation = _value.Get<Vector2>();
        }
        else
        {
            actualOrientation = lastOrientation;
        }

        transform.up = new Vector2(actualOrientation.x, Mathf.Clamp(actualOrientation.y, 0f, 1f));
    }

    public void OnPropulsionGamepad()
    {
        rigidbody.AddForce(transform.up * propulsion);
    }

    private void FixedUpdate()
    {

    }
}
