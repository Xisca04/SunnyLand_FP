using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Controller of the player

    [SerializeField] private float runSpeed = 1000f;
   // public float jumpForce = 10f;

    private Rigidbody2D _rigidbody;
    //private Animator _anim;

    private float horizontalMov = 0f;
    private bool lookRight = true;
   

    private void Awake()
    {
       // _anim = GetComponent<Animator>();
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalMov = Input.GetAxisRaw("Horizontal") * runSpeed;
    }

    private void FixedUpdate()
    {
        // que se mueva el personaje
        Movement(horizontalMov * Time.fixedDeltaTime);
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
}
