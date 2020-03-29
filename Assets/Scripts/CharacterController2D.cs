using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    private enum State
    {
        Normal, Rolling
    }

    public const float MOVE_SPEED = 6f;
    public Rigidbody2D rigidbody;
    private Vector3 moveDir;
    private Vector3 lastMoveDir;
    public Vector3 rollDir;
    public bool isDashButtonDown;
    public float dashAmount = 25f;
    public LayerMask layerMask;
    private State state;
    public float rollSpeed;
    public float maxRollSpeed;


    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        state = State.Normal;
    }

    // Update is called once per frame
    private void Update()
    {
        switch (state)
        {
            case State.Normal:
                var moveX = 0f;
                var moveY = 0f;

                if (Input.GetKey(KeyCode.W))
                {
                    moveY = +1f;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    moveY = -1f;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    moveX = -1f;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    moveX = +1f;
                }

                moveDir = new Vector3(moveX, moveY).normalized;
                if(moveX != 0 || moveY != 0)
                {
                    // not idle
                    lastMoveDir = moveDir;
                }

                //play movement animations

                if (Input.GetKeyDown(KeyCode.F))
                {
                    isDashButtonDown = true;
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rollDir = lastMoveDir;
                    rollSpeed = maxRollSpeed;
                    state = State.Rolling;
                }
                break;
            case State.Rolling:
                var rollSpeedDropMultiplier = 5f;
                rollSpeed -= rollSpeed * rollSpeedDropMultiplier * Time.deltaTime;

                var rollSpeedMin = MOVE_SPEED;
                if(rollSpeed < rollSpeedMin)
                {
                    state = State.Normal;
                }
                break;
        }
        
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case State.Normal:
                rigidbody.velocity = moveDir * MOVE_SPEED;

                if (isDashButtonDown)
                {
                    var dashPosition = transform.position + lastMoveDir * dashAmount;
                    var rayhit = Physics2D.Raycast(transform.position, lastMoveDir, dashAmount, layerMask);
                    if (rayhit.collider != null)
                    {
                        dashPosition = rayhit.point;
                    }

                    rigidbody.MovePosition(dashPosition);
                    print("dashing complete");
                    isDashButtonDown = false;
                }
                break;
            case State.Rolling:
                rigidbody.velocity = rollDir * rollSpeed;
                break;
        }
      
    }
}
