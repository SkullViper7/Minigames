using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;
using DG.Tweening;

public class Rocket : MonoBehaviour
{
    private PlayerInput playerInput;

    public float propulsion;
    public float rotationPerSecond;

    public float bounceForce;

    public float timeStunt;
    private bool isStunt;

    private Vector2 startOrientation;
    private Vector2 lastOrientation;
    private Vector2 actualOrientation;

    private new Rigidbody rigidbody;

    [SerializeField]
    private List<ParticleSystem> fires;

    void Start()
    {
        LinkPlayerToDevice();

        //Set up orientation
        startOrientation = transform.up;
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
            playerInput.onActionTriggered += OnAction;
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
        //List of all inputs for this game
        switch (context.action.name)
        {
            //Gamepad
            case "OrientationGamepad":
                if (!GameManager.Instance.isOnKeyboard)
                {
                    OrientationGamepad(context.action.ReadValue<Vector2>());
                }
                break;
            case "PropulsionGamepad":
                if (!GameManager.Instance.isOnKeyboard)
                {
                    if (context.started == true)
                    {
                        Propulsion();
                    }
                }
                break;
            //Keyboard
            //GreenRocket
            case "GreenRocketLeft":
                if (GameManager.Instance.isOnKeyboard)
                {
                    if (gameObject.name == "GreenRocket")
                    {
                        Debug.Log("test");
                        //OrientationGamepad(context.action.ReadValue<Vector2>());
                    }
                }
                break;
            case "GreenRocketRight":
                if (GameManager.Instance.isOnKeyboard)
                {
                    if (gameObject.name == "GreenRocket")
                    {
                        Debug.Log("test");
                        //OrientationGamepad(context.action.ReadValue<Vector2>());
                    }
                }
                break;
            case "GreenRocketPropulsion":
                if (GameManager.Instance.isOnKeyboard)
                {
                    if (gameObject.name == "GreenRocket")
                    {
                        Propulsion();
                    }
                }
                break;
            //RedRocket
            case "RedRocketLeft":
                if (GameManager.Instance.isOnKeyboard)
                {
                    if (gameObject.name == "RedRocket")
                    {
                        //OrientationGamepad(context.action.ReadValue<Vector2>());
                    }
                }
                break;
            case "RedRocketRight":
                if (GameManager.Instance.isOnKeyboard)
                {
                    if (gameObject.name == "RedRocket")
                    {
                        //OrientationGamepad(context.action.ReadValue<Vector2>());
                    }
                }
                break;
            case "RedRocketPropulsion":
                if (GameManager.Instance.isOnKeyboard)
                {
                    if (gameObject.name == "RedRocket")
                    {
                        Propulsion();
                    }
                }
                break;
            //BlueRocket
            case "BlueRocketLeft":
                if (GameManager.Instance.isOnKeyboard)
                {
                    if (gameObject.name == "BlueRocket")
                    {
                        //OrientationGamepad(context.action.ReadValue<Vector2>());
                    }
                }
                break;
            case "BlueRocketRight":
                if (GameManager.Instance.isOnKeyboard)
                {
                    if (gameObject.name == "BlueRocket")
                    {
                        //OrientationGamepad(context.action.ReadValue<Vector2>());
                    }
                }
                break;
            case "BlueRocketPropulsion":
                if (GameManager.Instance.isOnKeyboard)
                {
                    if (gameObject.name == "BlueRocket")
                    {
                        Propulsion();
                    }
                }
                break;
            //YellowRocket
            case "YellowRocketLeft":
                if (GameManager.Instance.isOnKeyboard)
                {
                    if (gameObject.name == "YellowRocket")
                    {
                        //OrientationGamepad(context.action.ReadValue<Vector2>());
                    }
                }
                break;
            case "YellowRocketRight":
                if (GameManager.Instance.isOnKeyboard)
                {
                    if (gameObject.name == "YellowRocket")
                    {
                        //OrientationGamepad(context.action.ReadValue<Vector2>());
                    }
                }
                break;
            case "YellowRocketPropulsion":
                if (GameManager.Instance.isOnKeyboard)
                {
                    if (gameObject.name == "YellowRocket")
                    {
                        Propulsion();
                    }
                }
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

    private void OrientationLeftKeyboard()
    {
        //Rotate the rocket
        transform.Rotate(new Vector3(0, 0, rotationPerSecond) * Time.deltaTime);
    }

    private void Propulsion()
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
        //Rocket is stunt when it collides to environment
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

    public IEnumerator Finish()
    {
        //When rocket has finished the race, it continue to fly upward
        if (transform.position.y >= 1700)
        {
            //If rocket is to hight, desactive it
            StopAllCoroutines();
            gameObject.SetActive(false);
        }

        //Add propulsion every half second
        transform.up = startOrientation;
        Propulsion();
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Finish());
    }
}
