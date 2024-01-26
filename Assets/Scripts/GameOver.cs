using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    private PlayerController _playerController;

    private float animTimeDie = 1.5f;

    // Añaadir --> coger altura del dead zone --> dejar al jugador en esa altura ---> animacion dead --> panel game over

    private void Start()
    {
        gameOverPanel.SetActive(false);
        _playerController = GetComponent<PlayerController>();
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
        _playerController.Die();
        StartCoroutine("GameOverCoroutine");
    }

    // Corrutina --> animaction die --> dsp 3 segundos aparece el panel game over

    private IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(animTimeDie);
        gameOverPanel.SetActive(true);
    }
}
