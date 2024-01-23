using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    private PlayerController _playerController;

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("DeadZone"))
        {
            GameOverLevels();
        }
    }

    public void GameOverLevels()
    {
        gameObject.SetActive(true);
        _playerController.Die();
    }
}
