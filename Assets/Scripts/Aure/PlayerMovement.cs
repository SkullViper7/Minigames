using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed;
    int directionX;
    int directionY;
    SpriteRenderer sr;
    Animator animator;
    float UpLimit;
    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        speed = 0;
        directionX = -1;
        directionY = -2;
    }

    private void FixedUpdate()
    {
        Vector2 velocite = new Vector2(speed * directionX * Time.deltaTime, directionY * Time.deltaTime);
        transform.Translate(velocite, Space.World);
        /*if (speed > 0)
        {
            
            
        }
        else
        {

        }*/
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Wall":
                animator.SetBool("IsJumping", false);
                speed = 0;
                Debug.Log("cha");
                directionY = -2;
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
                break;
            case "Projectile":
                Debug.Log("aie");
                break;
            case "DeadLimit":
                Debug.Log("dead");
                break;
            case "UpLimit":
                if(UpLimit == 0) 
                {
                    UpLimit = collision.transform.position.y;
                }
                break;
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall" && speed==0)
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
        speed = 25;
        
    }
}
