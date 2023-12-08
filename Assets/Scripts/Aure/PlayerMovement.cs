using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    float speed;
    int directionX;
    int directionY;
    SpriteRenderer sr;
    Animator animator;
    float UpLimit;
    AudioSource audioSource;
    public float _score;

    private PlayerInput playerInput;

    bool _isDead;
    private void Start()
    {
        LinkPlayerToDevice();

        switch (GameManager.Instance.maxPlayerCount)
        {
            case 2:
                if(gameObject.name != "Player3" || gameObject.name != "Player4")
                {
                    SlimeJumpManager.Instance._players.Add(this);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                break;
            case 3:
                if (gameObject.name != "Player4")
                {
                    SlimeJumpManager.Instance._players.Add(this);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                break;
            case 4:
                SlimeJumpManager.Instance._players.Add(this);
                break;
        }
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void LinkPlayerToDevice()
    {
        //If controller chosen is gamepad
        if (!GameManager.Instance.isOnKeyboard)
        {
            //Determine which PlayerInputControl to find depending of the name of the rocket
            switch (gameObject.name)
            {
                case "Player1":
                    TryToFindController("PlayerInputControl1");
                    break;
                case "Player2":
                    TryToFindController("PlayerInputControl2");
                    break;
                case "Player3":
                    TryToFindController("PlayerInputControl3");
                    break;
                case "Player4":
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
                case "Player1":
                    gameObject.SetActive(true);
                    SlimeJumpManager.Instance._players.Add(this);
                    break;
                case "Player2":
                    gameObject.SetActive(true);
                    SlimeJumpManager.Instance._players.Add(this);
                    break;
                case "Player3":
                    if (GameManager.Instance.maxPlayerCount >= 3)
                    {
                        gameObject.SetActive(true);
                        SlimeJumpManager.Instance._players.Add(this);
                    }
                    else
                    {
                        gameObject.SetActive(false);
                    }
                    break;
                case "Player4":
                    if (GameManager.Instance.maxPlayerCount == 4)
                    {
                        gameObject.SetActive(true);
                        SlimeJumpManager.Instance._players.Add(this);
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
            SlimeJumpManager.Instance._players.Add(this);
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
            case "ControllerMove":
                if (!GameManager.Instance.isOnKeyboard)
                {
                    OnMove();
                }
                break;
            case "Player1Move":
                if (GameManager.Instance.isOnKeyboard && gameObject.name == "Player1")
                {
                    OnMove();
                }
                break;
            case "Player2Move":
                if (GameManager.Instance.isOnKeyboard && gameObject.name == "Player2")
                {
                    OnMove();
                }
                break;
            case "Player3Move":
                if (GameManager.Instance.isOnKeyboard && gameObject.name == "Player3")
                {
                    OnMove();
                }
                break;
            case "Player4Move":
                if (GameManager.Instance.isOnKeyboard && gameObject.name == "Player4")
                {
                    OnMove();
                }
                break;
        }
    }

    public void GameStart()
    {
        
        speed = 0;
        directionX = 1;
        directionY = -1;
    }

    private void FixedUpdate()
    {
        if (!_isDead)
        {
            Vector2 velocite = new Vector2(speed * directionX * Time.deltaTime, directionY * Time.deltaTime);
            transform.Translate(velocite, Space.World);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (directionX != 0)
        {
            switch (collision.gameObject.tag)
            {
                case "Wall":
                    Transform theTransformCollision = collision.transform;
                    if (collision.ClosestPoint(transform.position).x < (theTransformCollision.position.x + (theTransformCollision.lossyScale.x / 2) * 80 / 100)
                    && collision.ClosestPoint(transform.position).x > (theTransformCollision.position.x - (theTransformCollision.lossyScale.x / 2) * 80 / 100))
                    {

                    }
                    else
                    {
                        animator.SetBool("IsJumping", false);
                        speed = 0;
                        directionY = -1;
                        if (directionX > 0)
                        {
                            sr.flipY = false;
                            directionX = -1;
                        }
                        else
                        {
                            sr.flipY = true;
                            directionX = 1;
                        }
                    }
                    break;
                case "Projectile":
                    Dead();
                    break;
                case "DeadLimit":
                    Dead();
                    break;
                case "UpLimit":
                    if (UpLimit == 0)
                    {
                        UpLimit = collision.transform.position.y;
                    }
                    break;
                case "Coin":
                    _score += 10;
                    collision.gameObject.SetActive(false);
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall" && speed == 0)
        {
            directionY = -5;
        }
    }

    void OnMove()
    {
        directionY = 2;
        if (UpLimit !=0 && transform.position.y >= UpLimit) 
        {
            directionY = 0;
        }
        animator.SetBool("IsJumping", true);
        audioSource.Play();
        speed = 25;
    }

    void Dead()
    {
        SlimeJumpManager.Instance.PlayerDie(this);
        _isDead = true;
        GetComponent<BoxCollider2D>().enabled = false;
        animator.SetBool("IsDead", true);
    }

    public void DesactivatePlayer()
    {
        gameObject.SetActive(false);
    }
}
