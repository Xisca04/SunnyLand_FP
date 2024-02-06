using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU_CountdownTimer : MonoBehaviour
{
    private void Update()
    {
        StartCoroutine("Destroy");
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);
    }
}
