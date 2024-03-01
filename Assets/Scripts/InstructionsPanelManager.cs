using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsPanelManager : MonoBehaviour
{
    // manager de muchas páginas de las instrucciones

    [SerializeField] private Button nextPageButton;
    [SerializeField] private Button previousPageButton;

    [SerializeField] private GameObject[] pages;
    private int currentPage;

    private void Awake()
    {
        nextPageButton.onClick.AddListener(NextPage);
        previousPageButton.onClick.AddListener(PreviousPage);
        DisplayCurrentPage();
    }

    private void NextPage()
    {
        if (currentPage < pages.Length - 1)
        {
            currentPage++;
            DisplayCurrentPage();
        }
    }

    private void PreviousPage()
    {
        // Retroceder a la página anterior si es posible
        if (currentPage > 0)
        {
            currentPage--;
            DisplayCurrentPage();
        }
    }

    private void DisplayCurrentPage()
    {
        foreach (GameObject obj in pages)
        {
            obj.SetActive(false);
        }

        pages[currentPage].SetActive(true);
    }
}
