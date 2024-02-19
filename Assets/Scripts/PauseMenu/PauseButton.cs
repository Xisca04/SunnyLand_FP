using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    // pause button

    private void Start()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }

    public void PauseMenuOn()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }
}
