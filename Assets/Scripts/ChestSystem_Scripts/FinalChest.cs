using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalChest : MonoBehaviour
{
    // Chest system -> collision --> animación --> scene --> panel explicativo
    [SerializeField] private ParticleSystem _particles;
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _particles.Stop();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Chest found");
            _anim.SetBool("IsOpened", true);
            _particles.Play();
            StartCoroutine("SendPlayer");
        }

    }

    private IEnumerator SendPlayer()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("C_Final_Level");
    }
}
