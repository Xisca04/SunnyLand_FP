using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    // Spawn random enemies to kill the player --> counter death enemies --> 10 deaths --> win --> > 10 --> loose

    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private ParticleSystem _emberParticles;
    private int enemyIndex;  

    public float startDelay = 1.5f;  //Determina qué tiempo tiene el jugador
    public float spawnInterial = 2f; //Determina cada cuánto sale el animal

    private void Start() // Llama periódicamente a la función SpawnRnadomAnimal
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterial);
        _emberParticles.Play();
        // cunaod gane stop particles
    }

    private void SpawnRandomAnimal() //Función que determina la aletoriedad de los tipos de animales que van apareciendo en una posición aleatoria
    {
        enemyIndex = Random.Range(0, _enemies.Length); //Índice aleatorio
        Instantiate(_enemies[enemyIndex], gameObject.transform.position, _enemies[enemyIndex].transform.rotation);
    }

}
