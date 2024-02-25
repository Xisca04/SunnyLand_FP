using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCall : MonoBehaviour
{
    private bool firstUpdate = true;
    private float sliderTimeLeft = 1.85f; // Time it takes for the slider to complete

    private void Update()
    {
        if (firstUpdate)
        {
            firstUpdate = false;
            StartCoroutine("LoadScene");
        }
    }

    // Couroutine that visually lengthens the loading scene 

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(sliderTimeLeft);
        Loader.LoaderCallBack();
    }
}
