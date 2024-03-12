using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CredistChest : MonoBehaviour
{
    // Chest system of the Chest_Final_Scene --> where the Player has to choose between 5 chests the correct one before the time's up

    // Variable of the croutine
    private float timeLeftCroutine = 1.5f;

    // Particles
    [SerializeField] private ParticleSystem _particles;

    // UI
    [SerializeField] private GameObject timeIsUpPanel;

    // To get the component
    private Animator _anim;

    // Reference
    [SerializeField] private PlayerController _playerController;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _particles.Stop();
        timeIsUpPanel.SetActive(false);
    }

    private void Update()
    {
        if(SimpleTimer.Instance.timeLeft == 0)
        {
            StartCoroutine("TimeIsUp");
        }
    }

    // Checks if the collision is form the Player and the chest which the player collisions it, is the correct or the wrong one
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("Finish")) // Win this final challenge - Chest Tag: Finish
        {
            // Animation + Activates the particles + Sends the Player to the Credits scene
            _anim.SetBool("IsOpened", true);
            _particles.Play();
            StartCoroutine("SendPlayer");
        } 
        else if(other.gameObject.CompareTag("Player") && gameObject.CompareTag("Repeat")) // Lose this final challenge - Chest Tag: Repeat
        {
            // Animation + Activates the particles + Sends the Player to restart the Final level
            _anim.SetBool("IsOpened", true);
            _particles.Play();
            StartCoroutine("SendAndRepeatLevel");
        }

    }

    // Win the level --> send player to the credits scene
    private IEnumerator SendPlayer()
    {
        yield return new WaitForSeconds(timeLeftCroutine);
        Loader.Load(Loader.Scene.CreditsScene);
    }

    // Lose the level --> send the player to restart the Final Level
    private IEnumerator SendAndRepeatLevel()
    {
        _playerController.enabled = false; // At this form the player can't move
        yield return new WaitForSeconds(timeLeftCroutine);
        Loader.Load(Loader.Scene.Final_Level);
        _playerController.enabled = true; 
    }

    // Lose the level if time's up --> restart the Final Level
    private IEnumerator TimeIsUp()
    {
        _playerController.enabled = false; // At this form the player can't move
        timeIsUpPanel.SetActive(true);
        yield return new WaitForSeconds(timeLeftCroutine);
        Loader.Load(Loader.Scene.Final_Level);
        _playerController.enabled = true; 
    }

}
