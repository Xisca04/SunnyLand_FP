using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPresentationGame : MonoBehaviour
{
    [SerializeField] private GameObject presentationPanel;
    [SerializeField] private GameObject mainMenu;

    private void Start()
    {
        presentationPanel.SetActive(true);
        mainMenu.SetActive(false);
        StartCoroutine("PresentationPanelOn");
    }

    private IEnumerator PresentationPanelOn()
    {
        yield return new WaitForSeconds(3.0f);
        presentationPanel.SetActive(false);
        mainMenu.SetActive(true);
    }
}
