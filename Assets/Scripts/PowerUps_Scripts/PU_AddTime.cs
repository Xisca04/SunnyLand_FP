using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU_AddTime : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CountdownTimer.Instance.timeLeft += CountdownTimer.Instance.timeToAdd;
            Destroy(this.gameObject);
        }
    }
}
