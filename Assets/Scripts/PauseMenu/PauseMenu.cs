using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Pause Menu

    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        mainMenuButton.onClick.AddListener(() => { Time.timeScale = 1f; SceneManager.LoadScene("MainMenu"); });
        resumeButton.onClick.AddListener(ResumeGame);
    }


    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }


    // Game's configuration if the Pause Menu is Off
    private void ResumeGame()
    {
        Time.timeScale = 1.0f; // TAMPOCO FUNCIONA CON TIME SCALE
        Hide();
        // SoundManager.PlaySound(SoundManager.Sound.ButtonOver);
    }
}
