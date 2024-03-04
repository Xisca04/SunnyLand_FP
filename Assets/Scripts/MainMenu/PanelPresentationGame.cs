using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelPresentationGame : MonoBehaviour
{
    // Every time the game opens from zero -> will apear first the Title's scene and then the main menu

    // UI
    [SerializeField] private GameObject presentationPanel;

    private void Start()
    {
        presentationPanel.SetActive(true);
        StartCoroutine("PresentationPanelOn");
    }

    // Coroutine that shows the Title and then goes to the Main Meny
    private IEnumerator PresentationPanelOn()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("MainMenu");
    }
}
