using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D boxCollider2D;

    private float horizontalInput;
    private float runSpeed = 10f;
    private float jumpForce = 8f;

    [SerializeField] private LayerMask groundLayerMask;

    private bool isJumping = false;

    private bool isOnTheGround;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        isOnTheGround = IsOnTheGround();

        Jump();
    }

    private void FixedUpdate()
    {
        Movement(horizontalInput * Time.fixedDeltaTime);
    }

    private void Movement(float move)
    {
        // Idle
        Vector2 velocity = new Vector2(runSpeed * horizontalInput, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = velocity;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnTheGround())
        {
            isJumping = true;



            _rigidbody2D.velocity = Vector2.up * jumpForce; // dirección del vector vertical por la fuerza de slto = player salta

        }
    }

    private bool IsOnTheGround() // Raycast
    {
        float extraHeightTest = 0.05f;
        RaycastHit2D raycastHit2D = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extraHeightTest, groundLayerMask);

        bool isOnTheGround = raycastHit2D.collider != null;

        Color rayColor = isOnTheGround ? Color.green : Color.red; // Si está en el suelo el rayo será verde sino rojo

        Debug.DrawRay(boxCollider2D.bounds.center,
             Vector2.down * (boxCollider2D.bounds.extents.y + extraHeightTest), rayColor);

        return isOnTheGround;
    }
}
