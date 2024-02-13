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
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button quitSettingsPanelButton;
    [SerializeField] private Button quitInstructionsPanelButton;

    [SerializeField] private GameObject instructionsPanel;
    [SerializeField] private GameObject settingsPanel;

    private void Awake()
    {
        // Programming the main menu buttons by code
        playButton.onClick.AddListener(GoToLevel1);
     
        instructionsButton.onClick.AddListener(ShowInstructionsPanel);

        bonusLevelButton.onClick.AddListener(GoToBonusLevel);

        settingsButton.onClick.AddListener(ShowSettingsPanel);

        quitButton.onClick.AddListener(Application.Quit);

        quitSettingsPanelButton.onClick.AddListener(HideSettingsPanel);

        quitInstructionsPanelButton.onClick.AddListener(HideInstructionsPanel);

        HideInstructionsPanel();
        HideSettingsPanel();
    }

    private void ShowInstructionsPanel()
    {
        instructionsPanel.SetActive(true);
    }

    private void HideInstructionsPanel()
    {
        instructionsPanel.SetActive(false);
    }

    private void ShowSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }

    private void HideSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }

    private void GoToLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    private void GoToBonusLevel()
    {
        SceneManager.LoadScene("Bonus_Level");
    }
}
