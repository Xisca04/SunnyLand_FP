using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathEnemiesCounter : MonoBehaviour
{
    // Counts every time the player kills an enemy
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private int enemyDeaths;
    [SerializeField] private TextMeshProUGUI enemyDeathsText;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private ParticleSystem _fireEmbersParticles;

    private GameObject spawnEnemies;
    
    private void Start()
    {
        enemyDeaths = 0;
        winPanel.SetActive(false);
        _fireEmbersParticles.Play();
    }

    private void Update()
    {
        CheckWinner();
    }

    private void OnCollisionEnter2D(Collision2D collision) // detecta si es un enemigo a lo que toca por debajo de él, pero si toca este que no sea desde arriba el enemigo mata al player
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Obtener la dirección del contacto
            ContactPoint2D contact = collision.contacts[0];
            Vector2 normal = contact.normal;

            if (Vector2.Dot(Vector2.up, normal) > 0.5f)
            {
                _playerController.ReboteJump();
                collision.gameObject.GetComponent<DeathEnemiesController>().TakeDamage();
                EnemyKilled();
            }
            else // Si el jugador choca con el enemigo desde los lados o por debajo, recibe daño
            {
                Debug.Log($"empiezas el nivel 2 de 0");
                gameObject.GetComponent<GameOver>().gameOverPanel.SetActive(true);
                _playerController.Die();
                StartCoroutine("LoseLevel");
            }
        }
    }

    private void EnemyKilled()
    {
        enemyDeaths++;
        enemyDeathsText.text = enemyDeaths.ToString();
    }

    private void CheckWinner()
    {
        if (enemyDeaths >= 10)
        {
            winPanel.SetActive(true);
            spawnEnemies = GameObject.FindGameObjectWithTag("SpawnEnemies");
            Destroy(spawnEnemies);
            Loader.Load(Loader.Scene.Level2);
            _gameManager.Load();
        }
    }

    private IEnumerator LoseLevel()
    {
        yield return new WaitForSeconds(1.5f);
        Loader.Load(Loader.Scene.Level2);
    }
}
