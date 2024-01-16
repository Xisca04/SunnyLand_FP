using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Controller of the player

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    private float horizontalInput;
    private float runSpeed = 10f;
    private float jumpForce = 8f;

    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask groundLayerMask;

    // private bool isOnTheGround; DUBUJAR RAYO

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>(); 
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        // isOnTheGround = IsOnTheGound(); DUBUJAR RAYO

        if (Input.GetKeyDown(KeyCode.Space) && IsOnTheGround())
        {
            _rigidbody2D.velocity = Vector2.up * jumpForce; // dirección del vector vertical por la fuerza de slto = player salta
        }
    }

    private void FixedUpdate()
    {
        Movement(horizontalInput * Time.fixedDeltaTime);
    }

    private void Movement(float move)
    {
        Vector2 velocity = new Vector2(runSpeed * horizontalInput, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = velocity;

        if (move > 0f)
        {
            // Girar personaje
            _spriteRenderer.flipX = false;
        }
        else if (move < 0f)
        {
            // Girar personaje
            _spriteRenderer.flipX = true;
        }
    }

    private bool IsOnTheGround() // impide el doble salto
    {
        float extraHeightTest = 0.05f;
        RaycastHit2D raycastHit2D = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extraHeightTest, groundLayerMask);

        bool isOnTheGround = raycastHit2D.collider != null;

        return isOnTheGround;
    }
}
