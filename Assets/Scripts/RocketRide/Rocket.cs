using System.Collections;
using System.Collections.Generic;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;
using DG.Tweening;

public class Rocket : MonoBehaviour
{
    private PlayerInput playerInput;

    public float propulsion;
    public float bounceForce;
    public float timeStunt;
    private bool isStunt;

    private Vector2 lastOrientation;
    private Vector2 actualOrientation;

    private new Rigidbody rigidbody;

    [SerializeField]
    private List<ParticleSystem> fires;

    void Start()
    {
        LinkPlayerToDevice();

        //Set up orientation
        lastOrientation = transform.up;
        actualOrientation = transform.up;

        //Get rigidbody
        rigidbody = GetComponent<Rigidbody>();
    }

    private void LinkPlayerToDevice()
    {
        //If controller chosen is gamepad
        if (!GameManager.Instance.isOnKeyboard)
        {
            //Determine which PlayerInputControl to find depending of the name of the rocket
            switch (gameObject.name)
            {
                case "GreenRocket":
                    TryToFindController("PlayerInputControl1");
                    break;
                case "RedRocket":
                    TryToFindController("PlayerInputControl2");
                    break;
                case "BlueRocket":
                    TryToFindController("PlayerInputControl3");
                    break;
                case "YellowRocket":
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
                case "GreenRocket":
                    gameObject.SetActive(true);
                    break;
                case "RedRocket":
                    gameObject.SetActive(true);
                    break;
                case "BlueRocket":
                    if (GameManager.Instance.maxPlayerCount >= 3)
                    {
                        gameObject.SetActive(true);
                    }
                    else
                    {
                        gameObject.SetActive(false);
                    }
                    break;
                case "YellowRocket":
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
            case "OrientationGamepad":
                OrientationGamepad(context.action.ReadValue<Vector2>());
                break;
            case "PropulsionGamepad":
                PropulsionGamepad();
                break;
        }
    }

    private void OrientationGamepad(Vector2 _value)
    {
        if (!isStunt)
        {
            lastOrientation = actualOrientation;

            //If joystick is not in neutral pos, actual orientation is the same as the joystick
            if (_value != new Vector2(0, 0))
            {
                actualOrientation = _value;
            }
            //Else keep the last orientation to not go to the neutral pos
            else
            {
                actualOrientation = lastOrientation;
            }

            //Rocket orientation is the same as the stick
            transform.up = new Vector2(actualOrientation.x, Mathf.Clamp(actualOrientation.y, 0f, 1f));
        }
    }

    private void PropulsionGamepad()
    {
        if (!isStunt)
        {
            //Rocket moves
            rigidbody.AddForce(transform.up * propulsion);

            //Active fires
            foreach (ParticleSystem fire in fires)
            {
                fire.Play();
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Environment"))
        {
            //Launch the coroutine for stunt
            isStunt = true;
            StartCoroutine(Stunt(timeStunt));

            //Shake
            transform.DOShakeRotation(3f, new Vector3(0, 0, 7), 30, 90);

            //Bounce when collide to the environment
            rigidbody.velocity = Vector2.Reflect(rigidbody.velocity.normalized * bounceForce, collision.contacts[0].normal);

            //Desactive fires
            foreach (ParticleSystem fire in fires)
            {
                fire.Stop();
            }
        }
    }

    private IEnumerator Stunt(float _time)
    {
        //Rocket is stunt
        yield return new WaitForSeconds(_time);
        isStunt = false;
    }
}
