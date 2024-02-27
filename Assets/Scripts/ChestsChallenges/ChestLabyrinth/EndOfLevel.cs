using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject winPanel;

    private void Start()
    {
        winPanel.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine("WonLevel");
        }
    }

    private IEnumerator WonLevel()
    {
        winPanel.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        ChargePlayerToCheckpoint();
        // Vuelta al check point con la partida igual que la había dejado y el chest destruido
    }

    private void ChargePlayerToCheckpoint()
    {
        if (PlayerPrefs.HasKey("PlayerPositionX") && PlayerPrefs.HasKey("PlayerPositionY"))
        {
            Debug.Log($"al checkpoint");
            Loader.Load(Loader.Scene.Level1);
        }
    }
}


