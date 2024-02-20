using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMovement : MonoBehaviour
{
    // movimmiento basico para los enemigo de la cueva

    private Rigidbody2D _rigidbody2D;

    [SerializeField] private float speed;
    [SerializeField] private float minDistance;

    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody2D.velocity = new Vector2(speed * transform.right.x, _rigidbody2D.velocity.y); // empezara´caminando hacia la derecha

        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, transform.right, minDistance, groundLayer);

        if (raycastHit2D)
        {
            // Girar
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

}
