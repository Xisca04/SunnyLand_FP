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

    private void PauseGame()
    {
        Time.fixedDeltaTime = 0f;
        Show();
        // SoundManager.PlaySound(SoundManager.Sound.ButtonClick);
        SimpleTimer.Instance.timeLeft = 0;
    }

    // Game's configuration if the Pause Menu is Off
    private void ResumeGame()
    {
        Time.fixedDeltaTime = 1f; // TAMPOCO FUNCIONA CON TIME SCALE
        Hide();
        // SoundManager.PlaySound(SoundManager.Sound.ButtonOver);
    }
}
