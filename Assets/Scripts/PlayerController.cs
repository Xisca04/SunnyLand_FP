using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Controller of the player

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D boxCollider2D;
    private Animator _animator;

    private float horizontalInput;

    private float runSpeed = 10f;
    private float jumpForce = 8f;

    [SerializeField] private LayerMask groundLayerMask;


    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>(); 
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        Jump();
    }

    private void FixedUpdate()
    {
        Movement(horizontalInput * Time.fixedDeltaTime);
    }

    private void Movement(float move)
    {
        Vector2 velocity = new Vector2(runSpeed * horizontalInput, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = velocity;
        _animator.SetBool("Run", false);
        _animator.SetBool("Jump", false);

        if (move > 0f)
        {
            // Girar personaje
            _spriteRenderer.flipX = false;
            _animator.SetBool("Run", true);
        }
        else if (move < 0f)
        {
            // Girar personaje
            _spriteRenderer.flipX = true;
            _animator.SetBool("Run", true);
        }
    }

    private void Jump()
    {
        if(IsOnTheGround() == true)
        {
            _animator.SetBool("Jump", false);
        }
        else if(IsOnTheGround() == false)
        {
            _animator.SetBool("Run", false);
            _animator.SetBool("Jump", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsOnTheGround())
        {
            _rigidbody2D.velocity = Vector2.up * jumpForce; // dirección del vector vertical por la fuerza de slto = player salta
        }
    }

    private bool IsOnTheGround() // impide el doble salto -- Raycast
    {
        float extraHeightTest = 0.05f;
        RaycastHit2D raycastHit2D = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extraHeightTest, groundLayerMask);

        bool isOnTheGround = raycastHit2D.collider != null;

        return isOnTheGround;
    }

    // Agacharse

}
