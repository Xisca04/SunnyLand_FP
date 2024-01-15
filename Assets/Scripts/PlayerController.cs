using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Controller of the player
    
    private Animator _anim;
    private Rigidbody2D _rigidbody;

    private float runSpeed = 450f;
    private float jumpForce = 400f;

    [SerializeField] private Transform groundController;
    [SerializeField] private Vector2 dimensionBox;
   
    [SerializeField] private bool isGround;
    [SerializeField] private LayerMask allGround;

    private float horizontalMov = 0f;
    private bool lookRight = true;
   
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalMov = Input.GetAxisRaw("Horizontal") * runSpeed;

        _anim.SetFloat("Horizontal", Mathf.Abs(horizontalMov)); // se añade el valor absoluto para controlar mejor la animación
    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapBox(groundController.position, dimensionBox, 0, allGround);

        _anim.SetBool("isGround", isGround);

        Movement(horizontalMov * Time.fixedDeltaTime);
        Jump();
    }

    private void Movement(float move)
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
    }

    private void Jump()
    {
        if (isGround && Input.GetKeyDown(KeyCode.Space))
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
