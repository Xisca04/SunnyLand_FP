using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Pause Menu

    // UI
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        // Programming the buttons by code
        mainMenuButton.onClick.AddListener(() => { Time.timeScale = 1f; Loader.Load(Loader.Scene.MainMenu);});
        resumeButton.onClick.AddListener(ResumeGame);
    }

    public void Show()
    {
        gameObject.SetActive(true); // Show the PausePanel
    }

    public void Hide()
    {
        gameObject.SetActive(false); // Hide the PausePanel
    }

    private void ResumeGame()
    {
        Time.timeScale = 1.0f; 
        Hide();
    }
}
