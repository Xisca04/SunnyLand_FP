using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Checkpoint --> detects player --> initialize the flag's animation

    // References
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Animator _animator;

    // Checkpoint's variable
    public bool activatedCheckpoint = false;

    // Coroutine's variable
    private float timeLeftCroutine = 1.5f;

    private void Start()
    {
        // Flag's animation default -> without flag
        _animator.GetComponent<Animator>();
        activatedCheckpoint = false;
        _animator.SetBool("IsChecked", false);
        _animator.SetBool("IsChecking", false);
    }

    // The player detects if he collisioned with the checkpoint
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint")) // When he collisions it
        {
            activatedCheckpoint = true;
            StartCoroutine("FlagAnim"); // Activation of the flag's animation
            _gameManager.Save(); // Saves the player position (from Game Manager)
        }
    }

    // Animation's sequence when the player touches the checkpoint
    private IEnumerator FlagAnim()
    {
        _animator.SetBool("IsChecking", true); // Beginnings of raising the flag
        yield return new WaitForSeconds(timeLeftCroutine);
        _animator.SetBool("IsChecking", false);
        _animator.SetBool("IsChecked", true); // The flag remains raised
    }
    
}
