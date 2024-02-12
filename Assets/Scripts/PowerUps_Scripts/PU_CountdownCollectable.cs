using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PU_CountdownCollectable : MonoBehaviour
{
    [SerializeField] private GameObject gems;
    
    private void Start()
    {
        gems.SetActive(false);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gems.SetActive(true);
            StartCoroutine("VFXOn");
        }
    }

    private IEnumerator VFXOn()
    {
        GetComponent<SpriteRenderer>().enabled = false; // Asi se puede ver el efecto visual
        Destroy(gameObject.GetComponent<BoxCollider2D>()); // Destruye el collider para que el player no colisione con este hasta que se detrya todo el objeto
        gameObject.transform.GetChild(0).gameObject.SetActive(true); // Accede al hijo del objeto uq es el que tiene el efecto visual
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject); // Destruye ambos 
    }
}
