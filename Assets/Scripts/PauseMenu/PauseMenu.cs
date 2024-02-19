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

    public void PauseGame()
    {
        Time.timeScale = 0f;
        Show();
        // SoundManager.PlaySound(SoundManager.Sound.ButtonClick);
    }

    // Game's configuration if the Pause Menu is Off
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Hide();
        // SoundManager.PlaySound(SoundManager.Sound.ButtonOver);
    }
}
