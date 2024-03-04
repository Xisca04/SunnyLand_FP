using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    // Credits system -> animation Winner --> Credits + MainMenu button

    // UI
    [SerializeField] private GameObject winnerPanel;
    [SerializeField] private GameObject credits;
    [SerializeField] private Button mainMenuButton;

    // Particles
    [SerializeField] private ParticleSystem starsParticles;

    // Coroutine's variable
    private float timeLeftCoroutine = 6.5f;

    private void Start() // By default shows the winner animation and the particles
    {
        mainMenuButton.onClick.AddListener(GoToMainMenu);
        winnerPanel.SetActive(true);
        credits.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
        starsParticles.Play();
        StartCoroutine("WinnerPanel");
    }

    private IEnumerator WinnerPanel() // After a while -> deactivate the winner animation and the particles -> Activate the credits and the MainMenu button
    {
        yield return new WaitForSeconds(timeLeftCoroutine);
        winnerPanel.SetActive(false);
        starsParticles.Stop();
        credits.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
    }

    // Load the Main Menu
    private void GoToMainMenu()
    {
        Loader.Load(Loader.Scene.MainMenu);
    }

}
