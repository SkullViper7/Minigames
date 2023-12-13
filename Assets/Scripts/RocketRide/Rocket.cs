using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class Rocket : MonoBehaviour
{
    private PlayerInput playerInput;

    public float propulsion;
    public float rotationPerSecond;

    private bool leftKeyIsHeld;
    private bool rightKeyIsHeld;

    public Coroutine stunnedCoroutine;
    public float bounceForce;
    public float timeStunned;
    public bool isStunned;

    private Vector2 startOrientation;
    private Vector2 lastOrientation;
    private Vector2 actualOrientation;

    private new Rigidbody rigidbody;

    [SerializeField]
    private List<ParticleSystem> fires;

    public bool hasFinished;

    [HideInInspector]
    public List<int> chrono = new();

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
                    if (!isStunned && !hasFinished && !RocketRideManager.Instance.gameIsOver)
                    {
                        OrientationGamepad(context.action.ReadValue<Vector2>());
                    }
                }
            break;
            case "PropulsionGamepad":
                if (!GameManager.Instance.isOnKeyboard)
                {
                    if (!isStunned && !hasFinished && !RocketRideManager.Instance.gameIsOver)
                    {
                        if (context.started == true)
                        {
                            Propulsion();
                        }
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
                        if (!isStunned && !hasFinished && !RocketRideManager.Instance.gameIsOver)
                        {
                            if (context.started == true)
                            {
                                leftKeyIsHeld = true;
                            }
                            else if (context.canceled == true)
                            {
                                leftKeyIsHeld = false;
                            }
                        }
                    }
                }
                break;
            case "GreenRocketRight":
                if (GameManager.Instance.isOnKeyboard)
                {
                    if (gameObject.name == "GreenRocket")
                    {
                        if (!isStunned && !hasFinished && !RocketRideManager.Instance.gameIsOver)
                        {
                            if (context.started == true)
                            {
                                rightKeyIsHeld = true;
                            }
                            else if (context.canceled == true)
                            {
                                rightKeyIsHeld = false;
                            }
                        }
                    }
                }
                break;
            case "GreenRocketPropulsion":
                if (GameManager.Instance.isOnKeyboard)
                {
                    if (gameObject.name == "GreenRocket")
                    {
                        if (!isStunned && !hasFinished && !RocketRideManager.Instance.gameIsOver)
                        {
                            if (context.started == true)
                            {
                                Propulsion();
                            }
                        }
                    }
                }
                break;
            //RedRocket
            case "RedRocketLeft":
                if (GameManager.Instance.isOnKeyboard)
                {
                    if (gameObject.name == "RedRocket")
                    {
                        if (!isStunned && !hasFinished && !RocketRideManager.Instance.gameIsOver)
                        {
                            if (context.started == true)
                            {
                                leftKeyIsHeld = true;
                            }
                            else if (context.canceled == true)
                            {
                                leftKeyIsHeld = false;
                            }
                        }
                    }
                }
                break;
            case "RedRocketRight":
                if (GameManager.Instance.isOnKeyboard)
                {
                    if (gameObject.name == "RedRocket")
                    {
                        if (!isStunned && !hasFinished && !RocketRideManager.Instance.gameIsOver)
                        {
                            if (context.started == true)
                            {
                                rightKeyIsHeld = true;
                            }
                            else if (context.canceled == true)
                            {
                                rightKeyIsHeld = false;
                            }
                        }
                    }
                }
                break;
            case "RedRocketPropulsion":
                if (GameManager.Instance.isOnKeyboard)
                {
                    if (gameObject.name == "RedRocket")
                    {
                        if (!isStunned && !hasFinished && !RocketRideManager.Instance.gameIsOver)
                        {
                            if (context.started == true)
                            {
                                Propulsion();
                            }
                        }
                    }
                }
                break;
            //BlueRocket
            case "BlueRocketLeft":
                if (GameManager.Instance.isOnKeyboard)
                {
                    if (gameObject.name == "BlueRocket")
                    {
                        if (!isStunned && !hasFinished && !RocketRideManager.Instance.gameIsOver)
                        {
                            if (context.started == true)
                            {
                                leftKeyIsHeld = true;
                            }
                            else if (context.canceled == true)
                            {
                                leftKeyIsHeld = false;
                            }
                        }
                    }
                }
                break;
            case "BlueRocketRight":
                if (GameManager.Instance.isOnKeyboard)
                {
                    if (gameObject.name == "BlueRocket")
                    {
                        if (!isStunned && !hasFinished && !RocketRideManager.Instance.gameIsOver)
                        {
                            if (context.started == true)
                            {
                                rightKeyIsHeld = true;
                            }
                            else if (context.canceled == true)
                            {
                                rightKeyIsHeld = false;
                            }
                        }
                    }
                }
                break;
            case "BlueRocketPropulsion":
                if (GameManager.Instance.isOnKeyboard)
                {
                    if (gameObject.name == "BlueRocket")
                    {
                        if (!isStunned && !hasFinished && !RocketRideManager.Instance.gameIsOver)
                        {
                            if (context.started == true)
                            {
                                Propulsion();
                            }
                        }
                    }
                }
                break;
            //YellowRocket
            case "YellowRocketLeft":
                if (GameManager.Instance.isOnKeyboard)
                {
                    if (gameObject.name == "YellowRocket")
                    {
                        if (!isStunned && !hasFinished && !RocketRideManager.Instance.gameIsOver)
                        {
                            if (context.started == true)
                            {
                                leftKeyIsHeld = true;
                            }
                            else if (context.canceled == true)
                            {
                                leftKeyIsHeld = false;
                            }
                        }
                    }
                }
                break;
            case "YellowRocketRight":
                if (GameManager.Instance.isOnKeyboard)
                {
                    if (gameObject.name == "YellowRocket")
                    {
                        if (!isStunned && !hasFinished && !RocketRideManager.Instance.gameIsOver)
                        {
                            if (context.started == true)
                            {
                                rightKeyIsHeld = true;
                            }
                            else if (context.canceled == true)
                            {
                                rightKeyIsHeld = false;
                            }
                        }
                    }
                }
                break;
            case "YellowRocketPropulsion":
                if (GameManager.Instance.isOnKeyboard)
                {
                    if (gameObject.name == "YellowRocket")
                    {
                        if (!isStunned && !hasFinished && !RocketRideManager.Instance.gameIsOver)
                        {
                            if (context.started == true)
                            {
                                Propulsion();
                            }
                        }
                    }
                }
                break;
        }
    }

    private void OrientationGamepad(Vector2 _value)
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

    private void OrientationLeftKeyboard()
    {
        //Rotate the rocket on the left
        transform.Rotate(new Vector3(0, 0, rotationPerSecond) * Time.deltaTime);

        //Clamp rotation
        float angle = transform.rotation.eulerAngles.z;
        if (angle <= 0f)
        {
            angle = 0f;
        }
        else if (angle >= 90f && angle <= 180f)
        {
            angle = 90f;
        }
        else if (angle <= 270f && angle > 180)
        {
            angle = 270f;
        }
        else if (angle >= 360f)
        {
            angle = 360f;
        }
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void OrientationRightKeyboard()
    {
        //Rotate the rocket on the right
        transform.Rotate(new Vector3(0, 0, -rotationPerSecond) * Time.deltaTime);

        //Clamp rotation
        float angle = transform.rotation.eulerAngles.z;
        if (angle <= 0f)
        {
            angle = 0f;
        }
        else if (angle >= 90f && angle <= 180f)
        {
            angle = 90f;
        }
        else if (angle <= 270f && angle > 180)
        {
            angle = 270f;
        }
        else if (angle >= 360f)
        {
            angle = 360f;
        }
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void FixedUpdate()
    {
        //Check if buttons are pressed and rotate
        if (leftKeyIsHeld)
        {
            OrientationLeftKeyboard();
        }
        if (rightKeyIsHeld)
        {
            OrientationRightKeyboard();
        }
    }

    private void Propulsion()
    {
        //Rocket moves
        rigidbody.AddForce(transform.up * propulsion);

        //Active fires
        foreach (ParticleSystem fire in fires)
        {
            fire.Play();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //Rocket is stunned when it collides to environment
        if (collision.gameObject.CompareTag("Environment") && !hasFinished && !RocketRideManager.Instance.gameIsOver)
        {
            //Bounce when collide to the environment
            rigidbody.velocity = Vector2.Reflect(rigidbody.velocity.normalized * bounceForce, collision.contacts[0].normal);

            if (!isStunned)
            {
                //Launch the coroutine for stunned
                stunnedCoroutine = StartCoroutine(Stunned(timeStunned));
            }
        }
    }

    private IEnumerator Stunned(float _time)
    {
        //Rocket is stunned
        isStunned = true;

        //Shake
        transform.DOShakeRotation(3f, new Vector3(0, 0, 7), 30, 90);

        //Desactive fires
        foreach (ParticleSystem fire in fires)
        {
            fire.Stop();
        }

        //Wait
        yield return new WaitForSeconds(_time);
        isStunned = false;
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

        //Rocket is oriented to the top
        transform.up = startOrientation;

        //Add propulsion every half second
        Propulsion();
        yield return new WaitForSeconds(0.5f);

        StartCoroutine(Finish());
    }
}