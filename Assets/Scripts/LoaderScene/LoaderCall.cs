using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCall : MonoBehaviour
{
    // Call of the load scene

    // Variable
    private bool firstUpdate = true;

    // Coroutine's variable
    private float animTimeLeft = 1.85f; // Time it takes for the animation

    private void Update()
    {
        if (firstUpdate)
        {
            firstUpdate = false;
            StartCoroutine("LoadScene");
        }
    }

    // Coroutine to make longer the load scene
    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(animTimeLeft);
        Loader.LoaderCallBack();
    }
}
