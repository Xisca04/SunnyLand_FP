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
    [SerializeField] private GameObject warningPanel;

    private void Start()
    {
        applesCollected = 0;
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        warningPanel.SetActive(false);
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
                SimpleTimer.Instance.timeLeft = 60; // paramos timer
                StartCoroutine("WinLevel");
            }
            else if (applesCollected < 10)
            {
                StartCoroutine("WarningPanel");
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
        warningPanel.SetActive(false); // aseguro que se desactive
        yield return new WaitForSeconds(3f);
        Loader.Load(Loader.Scene.MainMenu);
    }

    private IEnumerator LoseLevel()
    {
        losePanel.SetActive(true);
        warningPanel.SetActive(false); // aseguro que se desactive
        yield return new WaitForSeconds(3f);
        Loader.Load(Loader.Scene.MainMenu);
    }

    private IEnumerator WarningPanel()
    {
        warningPanel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        warningPanel.SetActive(false);
    }
}
