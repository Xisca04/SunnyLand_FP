using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    // panel winner --> tiempo --> creditos

    [SerializeField] private GameObject winnerPanel;
    [SerializeField] private GameObject credits;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private ParticleSystem starsParticles;

    private void Start()
    {
        mainMenuButton.onClick.AddListener(GoToMainMenu);
        winnerPanel.SetActive(true);
        credits.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
        starsParticles.Play();
        StartCoroutine("WinnerPanel");
    }

    private IEnumerator WinnerPanel()
    {
        yield return new WaitForSeconds(4f);
        winnerPanel.SetActive(false);
        starsParticles.Stop();
        credits.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
    }

    private void GoToMainMenu()
    {
        Loader.Load(Loader.Scene.MainMenu);
    }

}
