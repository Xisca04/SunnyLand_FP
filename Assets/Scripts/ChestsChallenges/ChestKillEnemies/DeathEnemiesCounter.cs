using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathEnemiesCounter : MonoBehaviour
{
    // Counts every time the player kills an enemy
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private int enemyDeaths;
    [SerializeField] private TextMeshProUGUI enemyDeathsText;
    
    private void Start()
    {
        enemyDeaths = 0;
    }

    private void Update()
    {
        if(enemyDeaths >= 10)
        {
            Debug.Log("al checkpoint nivel2");
        }
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
            }
        }
    }

    private void EnemyKilled()
    {
        enemyDeaths++;
        enemyDeathsText.text = enemyDeaths.ToString();
    }

}
