using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Checkpoint _checkpoint;
    public GameObject gameOverPanel;
    private PlayerController _playerController;

    private float animTimeDie = 1.0f;
    private float timeToRealoadLevel = 1.2f;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        _playerController = GetComponent<PlayerController>();
    }


    public void GameOverLevels()
    {
        StartCoroutine("GameOverCoroutine");
    }

    private IEnumerator GameOverCoroutine()
    {
        _playerController.Die();
        yield return new WaitForSeconds(animTimeDie);
        gameOverPanel.SetActive(true);
        yield return new WaitForSeconds(timeToRealoadLevel);
        ReachedCheckpoint();
        gameOverPanel.SetActive(false);
        _playerController.DieOff();
        Debug.Log("No muerto, sigue corriendo");
    }

    private void ReachedCheckpoint()
    {
        if (_checkpoint.activatedCheckpoint == true)
        {
            _gameManager.Load();
        }
        else if (_checkpoint.activatedCheckpoint == false)
        {
            ReloadLevel(); // desdel inicio
        }
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
