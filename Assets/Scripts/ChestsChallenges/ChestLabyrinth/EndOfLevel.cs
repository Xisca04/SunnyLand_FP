using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour
{
    // Labyrinth challenge --> Check if the Player collisions with the flag

    // Variables of the coroutine
    private float timeLeftCroutine = 2;

    // UI
    [SerializeField] private GameObject winPanel;

    private void Start()
    {
        winPanel.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine("WonLevel"); // Initialize the coroutine of overcomed the challenge
        }
    }

    // Activates the win panel and sends the player to the Level 2
    private IEnumerator WonLevel()
    {
        winPanel.SetActive(true);
        yield return new WaitForSeconds(timeLeftCroutine);
        Loader.Load(Loader.Scene.Level2);
    }
}


