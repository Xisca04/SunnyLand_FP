using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplainSystem : MonoBehaviour
{
    // Explain the challenge of the chest with a panel

    // UI
    [SerializeField] private GameObject explainPanel;

    // Coroutine's variabel
    private float timeLeftCoroutine = 1.5f;
    

    private void Start()
    {
        StartCoroutine("ExplainPanel"); // Shows the explanation of the challenge
    }

    private IEnumerator ExplainPanel()
    {
        explainPanel.SetActive(true);
        yield return new WaitForSeconds(timeLeftCoroutine);
        explainPanel.SetActive(false);
    }
}
