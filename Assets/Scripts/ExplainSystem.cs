using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplainSystem : MonoBehaviour
{
    // Explain the challenge of the chest

    [SerializeField] private GameObject explainPanel;
    

    private void Start()
    {
        StartCoroutine("ExplainPanel");
    }

    private IEnumerator ExplainPanel()
    {
        explainPanel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        explainPanel.SetActive(false);
    }
}
