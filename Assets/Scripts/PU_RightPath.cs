using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU_RightPath : MonoBehaviour
{
    // Power Up that shows the path to the right chest

    // Colllision con el player --> mostrar un objeto

    [SerializeField] private GameObject rightPath;

    private void Start()
    {
        rightPath.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            rightPath.SetActive(true);
        }
    }
}
