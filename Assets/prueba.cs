using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba : MonoBehaviour
{
    public GameObject titlePanel;

    // Start is called before the first frame update
    void Start()
    {
        titlePanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        Debug.Log($"play");
    }

    public void StartButton()
    {
        titlePanel.SetActive(false);
    }
}
