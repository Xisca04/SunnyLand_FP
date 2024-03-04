using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    // Controller of the player

    // To get the components
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D boxCollider2D;
    private Animator _animator;

    // Movement
    private float horizontalInput;
    public float runSpeed = 10f;

    // Jump
    private float jumpForce = 8f;
    public bool isJumping = false;
    private bool isOnTheGround = true;
    [SerializeField] private float bounceJump = 5f;
    [SerializeField] private LayerMask groundLayerMask;

    // Sound
    [SerializeField] private AudioClip[] playerSounds;
    private AudioSource _audioSource;

    // Get all the components for the Player's movement
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>(); 
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
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
        _animator.SetBool("Run", false);
        _animator.SetBool("Jump", false);

        // Run
        if (move > 0f)
        {
            // Turn Around the player
            _spriteRenderer.flipX = false;
            _animator.SetBool("Run", true);
        }
        else if (move < 0f)
        {
            // Turn Around the player
            _spriteRenderer.flipX = true;
            _animator.SetBool("Run", true);
        }
    }

    public void Jump()
    {
        // Jump Animation
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

        // Checks if the Player is on the ground and it pressed the sapce key
        if (Input.GetKeyDown(KeyCode.Space) && IsOnTheGround())
        {
            isJumping = true;

            _rigidbody2D.velocity = Vector2.up * jumpForce; // Direction Vector Up * jump force = Jump Player

            _audioSource.PlayOneShot(playerSounds[0]);
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
    private bool IsOnTheGround() // Raycast to check if the Player is on the ground or not -> and if the player can jump or not
    {
        float extraHeightTest = 0.03f;
        RaycastHit2D raycastHit2D = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extraHeightTest, groundLayerMask);

        bool isOnTheGround = raycastHit2D.collider != null;

        Color rayColor = isOnTheGround ? Color.green : Color.red; // The ray will be green if the Player is on the ground, if not it will be red

        Debug.DrawRay(boxCollider2D.bounds.center,
             Vector2.down * (boxCollider2D.bounds.extents.y + extraHeightTest), rayColor);

        return isOnTheGround;
    }

    public bool CheckJump() // Make sure if the Player is jumping
    {
        return isJumping;
    }

    // For kill the enemies --> the Player will make the rebounce
    public void BounceJump()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, bounceJump);
    }


    // Activates the Die's animation and play the death sound
    public void Die()
    {
        _animator.SetBool("Die", true);
        _audioSource.PlayOneShot(playerSounds[1]);
    }

    // Deactivates the Die's animation
    public void DieOff()
    {
        _animator.SetBool("Die", false);
    }

    // For the checkpoint system
    public Vector3 GetPosition() // Return the Player's position
    {
        return transform.position;
    }

    public void SetPosition(Vector3 newPosition) // Get the Player's position and then will change for another
    {
        transform.position = newPosition;
    }

}
