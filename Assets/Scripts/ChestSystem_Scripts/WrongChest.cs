using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WrongChest : MonoBehaviour
{
    [SerializeField] private GameObject wrongChestPanel;

    private void Start()
    {
        wrongChestPanel.SetActive(false);
    }

    public void WrongChestSystem()
    {
        StartCoroutine("ShowWrongChestPanel");
    }

    private IEnumerator ShowWrongChestPanel()
    {
        wrongChestPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        wrongChestPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
