using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed;
    int directionX;
    int directionY;
    SpriteRenderer sr;
    Animator animator;
    float UpLimit;
    AudioSource audioSource;


    private void Start()
    {
        SlimeJumpManager.Instance._players.Add(this);
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    public void GameStart()
    {
        
        speed = 0;
        directionX = 1;
        directionY = -1;
    }

    private void FixedUpdate()
    {
        Vector2 velocite = new Vector2(speed * directionX * Time.deltaTime, directionY * Time.deltaTime);
        transform.Translate(velocite, Space.World);
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
        gameObject.SetActive(false);
    }
}
