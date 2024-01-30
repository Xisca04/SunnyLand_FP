using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    private Scene currentScene;

    private void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        currentScene = SceneManager.GetActiveScene();
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
        ChargePlayerCheckpoint();
        // Vuelta al check point con la partida igual que la había dejado y el chest destruido
    }

    private void ChargePlayerCheckpoint()
    {
        if (PlayerPrefs.HasKey("PlayerPositionX") && PlayerPrefs.HasKey("PlayerPositionY"))
        {
            _gameManager.Load();
            Debug.Log($"al checkpoint");
            SceneManager.LoadScene("Level1");

        }
    }

    private IEnumerator LoseLevel()
    {
        losePanel.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        // Vuelve a empezar el nivel de nuevo
        SceneManager.LoadScene("Level1");
    }
}
