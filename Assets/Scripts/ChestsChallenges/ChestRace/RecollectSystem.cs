using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RecollectSystem : MonoBehaviour
{
    private int applesCollected;
    public TextMeshProUGUI applesCollectedText;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        applesCollected = 0;
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    private void Update()
    {
        if(SimpleTimer.Instance.timeLeft == 0)
        {
            StartCoroutine("LoseLevel");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            other.gameObject.GetComponent<AppleRaceLevel>().DestroyApple();
            applesCollected++;
            UpdateApplesUI();
        }

        if (other.gameObject.CompareTag("FinishRace"))
        {
            if (applesCollected >= 10 && SimpleTimer.Instance.timeLeft > 0)
            {
                // && TIMER NO A CERO
                // SimpleTimer.Instance.timeLeft = 0;
                StartCoroutine("WinLevel");
            }
            else if (applesCollected < 10)
            {
                // && TIMER  A CERO
                // SimpleTimer.Instance.timeLeft = 0;
                StartCoroutine("LoseLevel"); 
            }
        }
    }

   private void UpdateApplesUI()
   {
     applesCollectedText.text = applesCollected.ToString();
   }

    private IEnumerator WinLevel()
    {
        winPanel.SetActive(true);
        yield return new WaitForSeconds(3f);
        GoToCheckpoint();
    }

    private IEnumerator LoseLevel()
    {
        losePanel.SetActive(true);
        yield return new WaitForSeconds(3f);
        Loader.Load(Loader.Scene.Level2);
    }

    private void GoToCheckpoint()
    {
        Loader.Load(Loader.Scene.Level2);
        _gameManager.Load();
    }
}
