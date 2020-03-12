using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rigidbody;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);

        var lookDir = mousePos - rigidbody.position;
        var angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rigidbody.rotation = angle;
    }
}
