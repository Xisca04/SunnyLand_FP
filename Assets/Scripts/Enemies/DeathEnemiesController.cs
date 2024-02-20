using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEnemiesController : MonoBehaviour
{

    private void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false); // desactiva el hijo
    }

    public void TakeDamage()
    {
        StartCoroutine("VFXDeath");
    }

    private IEnumerator VFXDeath()
    {
        GetComponent<SpriteRenderer>().enabled = false; // Asi se puede ver el efecto visual
        Destroy(gameObject.GetComponent<BoxCollider2D>()); // Destruye el collider para que el player no colisione con este hasta que se detrya todo el objeto
        gameObject.transform.GetChild(0).gameObject.SetActive(true); // Accede al hijo del objeto uq es el que tiene el efecto visual
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject); // Destruye ambos 

        // añadir el score de cada enemigo
    }
}
