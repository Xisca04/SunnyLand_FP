using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    // logica botones y panel del main menu

    [SerializeField] private Button playButton;
    [SerializeField] private Button instructionsButton; 
    [SerializeField] private Button bonusLevelButton; 
    [SerializeField] private Button quitButton;
    [SerializeField] private Button quitInstructionsPanelButton;
    [SerializeField] private GameObject instructionsPanel;

    private void Awake()
    {
        // Programming the main menu buttons by code
        playButton.onClick.AddListener(GoToLevel1);
     
        instructionsButton.onClick.AddListener(ShowInstructionsPanel);

        bonusLevelButton.onClick.AddListener(GoToMinigame);

        quitButton.onClick.AddListener(Application.Quit);

        quitInstructionsPanelButton.onClick.AddListener(HideInstructionsPanel);

        HideInstructionsPanel();
    }

    private void ShowInstructionsPanel()
    {
        instructionsPanel.SetActive(true);
    }

    private void HideInstructionsPanel()
    {
        instructionsPanel.SetActive(false);
    }

    private void GoToLevel1()
    {
        Loader.Load(Loader.Scene.Level1);
    }

    private void GoToMinigame()
    {
        Loader.Load(Loader.Scene.Minigame);
    }
}
