using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Controller of the player

    private float runSpeed = 450f;
    public float jumpForce = 10f;

    [SerializeField] private Transform groundController;
    [SerializeField] private Vector2 dimensionBox;
    [SerializeField] private bool isGround;
    [SerializeField] private LayerMask allGround;

    private bool canJump = false;

    private Rigidbody2D _rigidbody;
    private Animator _anim;

    private float horizontalMov = 0f;
    private bool lookRight = true;
   

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalMov = Input.GetAxisRaw("Horizontal") * runSpeed;

        _anim.SetFloat("Horizontal", Mathf.Abs(horizontalMov)); // se añade el valor absoluto para controlar mejor la animación

        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Jump
            canJump = true;
        }
    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapBox(groundController.position, dimensionBox, 0, allGround);
        // que se mueva el personaje
        Movement(horizontalMov * Time.fixedDeltaTime, jumpForce);

        canJump = false;
    }

    private void Movement(float move, float jump)
    {
        Vector2 velocity = new Vector2(move, _rigidbody.velocity.y);
        _rigidbody.velocity = velocity;
        
        if(move > 0f && !lookRight)
        {
            // Girar personaje
            TurnAroundR();
        }
        else if(move < 0f && lookRight)
        {
            // Girar personaje
            TurnAroundL();
        }

        if(isGround && Input.GetKeyDown(KeyCode.Space))
        {
            isGround = false;
            _rigidbody.AddForce(new Vector2(0f, jumpForce));
        }
    }

    private void TurnAroundL() // Gira el sprite de dirección
    {
        lookRight = !lookRight;
        Vector2 scale = transform.localScale;
        scale.x = -10;
        transform.localScale = scale;
    }

    private void TurnAroundR() // Gira el sprite de dirección
    {
        lookRight = !lookRight;
        Vector2 scale = transform.localScale;
        scale.x = 10;
        transform.localScale = scale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(groundController.position, dimensionBox);
    }
}
