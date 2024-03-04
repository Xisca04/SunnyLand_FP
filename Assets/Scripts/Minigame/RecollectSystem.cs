using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RecollectSystem : MonoBehaviour
{
    // Minigame mechanic --> Recollect apples

    // Variable of the counter
    private int applesCollected;

    // Coroutine's variables
    private float timeLeftCoroutine = 3;
    private float timeLeftPanelCoroutine = 1.5f;

    // UI
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
        if(SimpleTimer.Instance.timeLeft == 0) // If timer = 0 -> Game Over
        {
            StartCoroutine("LoseLevel");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Apple")) // Every time the Player collision with an apple --> destroys it and update the counter
        {
            other.gameObject.GetComponent<AppleRaceLevel>().DestroyApple();
            applesCollected++;
            UpdateApplesUI();
        }

        if (other.gameObject.CompareTag("FinishRace")) // Detects the collisiion between the player and the flag
        {
            if (applesCollected >= 10 && SimpleTimer.Instance.timeLeft > 0) // Player has 10 or more apples --> Win Level
            {
                SimpleTimer.Instance.timeLeft = 60; // Stop the timer
                StartCoroutine("WinLevel");
            }
            else if (applesCollected < 10) // Less than 10 -> shows warning panel
            {
                StartCoroutine("WarningPanel");
            }
        }
    }

    // Update visually the counter text
   private void UpdateApplesUI()
   {
     applesCollectedText.text = applesCollected.ToString();
   }

    private IEnumerator WinLevel()
    {
        winPanel.SetActive(true);
        warningPanel.SetActive(false); // Make sure it is deactivated
        yield return new WaitForSeconds(timeLeftCoroutine);
        Loader.Load(Loader.Scene.MainMenu);
    }

    // If the player lose --> goes to the MainMenu
    private IEnumerator LoseLevel()
    {
        losePanel.SetActive(true);
        warningPanel.SetActive(false); // Make sure it is deactivated
        yield return new WaitForSeconds(timeLeftCoroutine);
        Loader.Load(Loader.Scene.MainMenu);
    }

    // Activates the warning panel that shows that the player has to recollect more apples
    private IEnumerator WarningPanel()
    {
        warningPanel.SetActive(true);
        yield return new WaitForSeconds(timeLeftPanelCoroutine);
        warningPanel.SetActive(false);
    }
}
