using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsManager : MonoBehaviour
{
    // panel winner --> tiempo --> creditos

    [SerializeField] private GameObject winnerPanel;

    private void Start()
    {
        winnerPanel.SetActive(true);
        StartCoroutine("WinnerPanel");
    }

    private IEnumerator WinnerPanel()
    {
        yield return new WaitForSeconds(3.5f);
        winnerPanel.SetActive(false);
    }
}
