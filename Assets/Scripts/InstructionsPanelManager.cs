using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsPanelManager : MonoBehaviour
{
    // manager de muchas páginas de las instrucciones

    [SerializeField] private Button nextPageButton;
    [SerializeField] private Button previousPageButton;

    [SerializeField] private GameObject page1;
    [SerializeField] private GameObject page2;

    private void Awake()
    {
        nextPageButton.onClick.AddListener(NextPage);
        previousPageButton.onClick.AddListener(PreviousPage);
        page1.SetActive(true);
        page2.SetActive(false);
    }

    private void NextPage()
    {
        page1.SetActive(false);
        page2.SetActive(true);
    }

    private void PreviousPage()
    {
        page1.SetActive(true);
        page2.SetActive(false);
    }
}
