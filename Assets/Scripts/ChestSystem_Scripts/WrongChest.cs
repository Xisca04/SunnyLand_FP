using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WrongChest : MonoBehaviour
{
    // System for the wrongs chests of the game
    // Coroutine's variable
    private float timeLeftCroutine = 1.5f;

    // UI
    [SerializeField] private GameObject wrongChestPanel;

    private void Start()
    {
        wrongChestPanel.SetActive(false);
    }

    public void WrongChestSystem()
    {
        StartCoroutine("ShowWrongChestPanel");
    }

    // Coroutine -> shows the panel and after a while restart the respective level
    private IEnumerator ShowWrongChestPanel()
    {
        wrongChestPanel.SetActive(true);
        yield return new WaitForSeconds(timeLeftCroutine);
        wrongChestPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
