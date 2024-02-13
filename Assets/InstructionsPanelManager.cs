using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsPanelManager : MonoBehaviour
{
    // manager de muchas páginas de las instrucciones

    [SerializeField] private Button nextPageButton;
    [SerializeField] private Button previousPageButton;

    [SerializeField] private GameObject page1Panel;
    [SerializeField] private GameObject page2Panel;

    private void Awake()
    {
        nextPageButton.onClick.AddListener(NextPage);
        previousPageButton.onClick.AddListener(PreviousPage);

        page1Panel.SetActive(true);
        page2Panel.SetActive(false);
    }

    private void NextPage()
    {
        page1Panel.SetActive(false);
        page2Panel.SetActive(true);
    }

    private void PreviousPage()
    {
        page1Panel.SetActive(true);
        page2Panel.SetActive(false);
    }
}
