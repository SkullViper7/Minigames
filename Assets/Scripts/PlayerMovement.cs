using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed;
    int Direction;
    void Start()
    {
        speed = 0;
        Direction = 1;
        OnMove();
    }

    private void FixedUpdate()
    {
        if(speed > 0)
        {
            Vector2 velocite = new Vector2 (speed * Time.deltaTime, 0);
            transform.Translate(velocite, Space.World);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("d");
        if(collision.gameObject.tag == "Wall")
        {
            speed = 0;
            if(Direction > 0)
            {
                Direction = -1;
            }
            else
            {
                Direction = 1;
            }
        }
    }

    void OnMove()
    {
        speed = 5;
    }
}
