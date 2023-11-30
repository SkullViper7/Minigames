using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed;
    int directionX;
    int directionY;
    void Start()
    {
        speed = 0;
        directionX = 1;
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
                speed = 0;
                directionY = -2;
                if (directionX > 0)
                {
                    directionX = -1;
                }
                else
                {
                    directionX = 1;
                }
                break;
            case "Projectile":
                Debug.Log("aie");
                break;
        }        
    }

    void OnMove()
    {
        speed = 25;
        directionY = 1;
    }
}
