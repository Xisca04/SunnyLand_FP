using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU_CountdownTimer : MonoBehaviour
{
    // Destroy the object after a while

    //Coroutine's variable
    private float timeLeftCoroutine = 5;

    private void Update()
    {
        StartCoroutine("Destroy");
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(timeLeftCoroutine);
        Destroy(this.gameObject);
    }
}
