using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalChest : MonoBehaviour
{
    // Final Chest of the Final Level

    // Variable of the croutine
    private float timeLeftCroutine = 0.3f;

    // Particles
    [SerializeField] private ParticleSystem _particles;

    // To get the component
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _particles.Stop();
    }

    // If the Player collisions with the chest -> activates the chest' animation and send the player to the scene
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _anim.SetBool("IsOpened", true);
            _particles.Play();
            StartCoroutine("SendPlayer");
        }

    }

    // Sends the player to the Final Challenge Chest
    private IEnumerator SendPlayer()
    {
        yield return new WaitForSeconds(timeLeftCroutine);
        Loader.Load(Loader.Scene.C_Final_Level);
    }
}
