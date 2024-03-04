using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    // Pause button

    private void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false); // Deactivate the first children by default
    }

    public void PauseMenuOn() // Activates the first children (PausePanel) and stops the time
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
