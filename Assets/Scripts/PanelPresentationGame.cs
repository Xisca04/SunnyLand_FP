using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPresentationGame : MonoBehaviour
{
    [SerializeField] private GameObject presentationPanel;

    private void Start()
    {
        presentationPanel.SetActive(true);
        StartCoroutine("PresentationPanelOn");
    }

    private IEnumerator PresentationPanelOn()
    {
        yield return new WaitForSeconds(3.0f);
        presentationPanel.SetActive(false);
    }
}
