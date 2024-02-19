using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Checkpoint --> detecta player --> detecta que ha pasado por el checkpoint

    [SerializeField] private GameManager _gameManager;
    //[SerializeField] private Animator _animator;
    //[SerializeField] private BoxCollider2D _boxCollider;

    public bool activatedCheckpoint = false;

    private void Start()
    {
        //_animator.GetComponent<Animator>();
       // _boxCollider = GetComponent<BoxCollider2D>();
        activatedCheckpoint = false;
        //_animator.SetBool("IsChecked", false);
        //_animator.SetBool("IsChecking", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            Debug.Log($"checkpoint");
            activatedCheckpoint = true;
            //StartCoroutine("FlagAnim");
            _gameManager.Save();
        }
    }

    /*
    private IEnumerator FlagAnim()
    {
        _animator.SetBool("IsChecking", true);
        yield return new WaitForSeconds(1.5f);
        _animator.SetBool("IsChecking", false);
        _animator.SetBool("IsChecked", true);

    }
    */
}
