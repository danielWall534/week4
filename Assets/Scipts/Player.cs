using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public float movespeed = 10;
    float horizontal;
    float vertical;

    Rigidbody2D body;
    Vector2 velocity;
    Vector3 mousePosition;
    Vector3 direction;
    int totalXP;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //movement
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        velocity.x = horizontal * movespeed;
        velocity.y = vertical * movespeed;

        body.velocity = velocity;

        //Rotation
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        direction = mousePosition - transform.position;
        direction.Normalize();
        transform.up = direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("XP"))
        {
            //get the pickup class instance from the object we called with
            Pickup xp = collision.gameObject.GetComponent<Pickup>();
            totalXP += xp.Amount;

            Destroy(collision.gameObject);
        }
    }
}
