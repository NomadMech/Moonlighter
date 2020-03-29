using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    Rigidbody2D body;
    PlayerActions playerAction;
    public Collider2D collider;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;
    public float dashSpeed;
    public float dashTime;
    public float startDashTime;
    public int direction;
    public bool isDashing;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        GetComponent<PlayerActions>().attack += Attack;
    }



    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        
    }

    void Attack()
    {
        Debug.Log("Attack buttong pressed");
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
           
                // limit movement speed diagonally, so you move at 70% speed
                horizontal *= moveLimiter;
                vertical *= moveLimiter;
 
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);


        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                direction = 1;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                direction = 2;
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                direction = 3;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                direction = 4;
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
            }
            else
            {
                dashTime -= Time.deltaTime;
                if(direction == 1)
                {
                 

                }
                else if (direction == 2)
                {

                }
                else if (direction == 3)
                {

                }
                else if (direction == 4)
                {

                }
            }
        }

    }
}
