using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Game Over system

    // References
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Checkpoint _checkpoint;

    // UI
    public GameObject gameOverPanel;

    // To get the component
    private PlayerController _playerController;

    // Coroutines' variables
    private float animTimeDie = 1.0f;
    private float timeToRealoadLevel = 1.2f;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        _playerController = GetComponent<PlayerController>();
    }

    // Activates the system of the Game Over
    public void GameOverLevels()
    {
        StartCoroutine("GameOverCoroutine");
    }

    private IEnumerator GameOverCoroutine()
    {
        _playerController.Die(); // Player's die animation
        _playerController.enabled = false; // At this form the player can't move
        yield return new WaitForSeconds(animTimeDie);
        gameOverPanel.SetActive(true); // Activates the game Over panel
        yield return new WaitForSeconds(timeToRealoadLevel);
        ReachedCheckpoint(); // Check if the player has passed the checkpoint
        _playerController.enabled = true; // Then the player when restart the level can move
        gameOverPanel.SetActive(false); // Desactivates the game Over panel
        _playerController.DieOff(); // Desactivate the die's animation
    }

    // If the player has collisions the checkpoint --> he restart the level from that point
    private void ReachedCheckpoint()
    {
        if (_checkpoint.activatedCheckpoint == true)
        {
            _gameManager.Load(); // Load the saved position (from Game Manager)
        }
        else if (_checkpoint.activatedCheckpoint == false)
        {
            ReloadLevel(); // Restart the Level
        }
    }

    // Get the active scene to restart the respective level
    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
