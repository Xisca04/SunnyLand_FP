using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU_CorrectPath : MonoBehaviour
{
    // Power Up that shows the path to the right chest

    // Colllision con el player --> mostrar un objeto

    [SerializeField] private GameObject correctPath;

    private void Start()
    {
        correctPath.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            correctPath.SetActive(true);
        }
    }
}
