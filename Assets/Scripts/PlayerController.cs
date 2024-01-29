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
    public float runSpeed = 10f;
    private float jumpForce = 8f;

    [SerializeField] private LayerMask groundLayerMask;

    private bool isCrouching = false;
    private bool isJumping = false;

    private bool isOnTheGround;

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

        isOnTheGround = IsOnTheGround();

        Jump();
        Crouch();
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
        _animator.SetBool("Run", false);
        _animator.SetBool("Jump", false);

        // Run
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
        if (IsOnTheGround() == true)
        {
            _animator.SetBool("Jump", false);
            _animator.SetBool("Fall", false);
            isJumping = false;
        }
        else if (IsOnTheGround() == false)
        {
            _animator.SetBool("Run", false);
            _animator.SetBool("Jump", true);
            _animator.SetBool("Crouch", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsOnTheGround() && !isCrouching)
        {
            isJumping = true;

            _rigidbody2D.velocity = Vector2.up * jumpForce; // dirección del vector vertical por la fuerza de slto = player salta

        }

        // Fall animation

        if (_rigidbody2D.velocity.y < 0)
        {
            _animator.SetBool("Fall", true);
        }
        else if (_rigidbody2D.velocity.y > 0)
        {
            _animator.SetBool("Fall", false);
        }


    }
    private bool IsOnTheGround() // Raycast
    {
        float extraHeightTest = 0.03f;
        RaycastHit2D raycastHit2D = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extraHeightTest, groundLayerMask);

        bool isOnTheGround = raycastHit2D.collider != null;

        Color rayColor = isOnTheGround ? Color.green : Color.red; // Si está en el suelo el rayo será verde sino rojo

        Debug.DrawRay(boxCollider2D.bounds.center,
             Vector2.down * (boxCollider2D.bounds.extents.y + extraHeightTest), rayColor);

        return isOnTheGround;
    }
    
    // Agacharse
    
    private void Crouch()
    {
        if (Input.GetButton("Fire1")) // Manteniendo botón dch ratón --> está agachado y puede moverse también
        {
            isCrouching = !isCrouching;
            
            if (isCrouching)
            {
                _animator.SetBool("Crouch", true);
            }
        }
        else
        {
            _animator.SetBool("Crouch", false);
        }
    }
    
    public void Die()
    {
        _animator.SetBool("Die", true);
    }
    
}
