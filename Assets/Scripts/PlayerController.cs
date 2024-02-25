using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Controller of the player

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D boxCollider2D;
    public Animator _animator;

    private float horizontalInput;
    public float runSpeed = 10f;
    private float jumpForce = 8f;

    [SerializeField] private float rebotejump = 5f;

    [SerializeField] private LayerMask groundLayerMask;

    [SerializeField] private AudioClip[] playerSounds;

    private bool isCrouching = true;
    public bool isJumping = false;

    private bool isOnTheGround = true;
    private AudioSource _audioSource;

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

    public void Jump()
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

        if (Input.GetKeyDown(KeyCode.Space) && IsOnTheGround())
        {
            isJumping = true;

            _rigidbody2D.velocity = Vector2.up * jumpForce; // dirección del vector vertical por la fuerza de slto = player salta

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

    public bool CheckJump()
    {
        return isJumping;
    }

    public void ReboteJump()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, rebotejump);
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
        _audioSource.PlayOneShot(playerSounds[1]);
    }

    public void DieOff()
    {
        _animator.SetBool("Die", false);
    }

    public Vector3 GetPosition() // devuelve la posición del player en ese momento
    {
        return transform.position;
    }

    public void SetPosition(Vector3 newPosition) // tomará la posición del player y la cambiará por una que entrará como parámetro
    {
        transform.position = newPosition;
    }

}
