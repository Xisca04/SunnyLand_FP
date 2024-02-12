using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    private void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false); // Nos aseguramos de que este desactivado desde el principio
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("VFXOn");

            if (gameObject.CompareTag("Gem"))
            {
                collision.gameObject.GetComponent<Score>().AddScore(Score.GEM_SCORE);
            }
            else if (gameObject.CompareTag("Cherry"))
            {
                collision.gameObject.GetComponent<Score>().AddScore(Score.CHERRY_SCORE);
            }
        }
    }

    private IEnumerator VFXOn()
    {
        GetComponent<SpriteRenderer>().enabled = false; // Asi se puede ver el efecto visual
        Destroy(gameObject.GetComponent<BoxCollider2D>()); // Destruye el collider para que el player no colisione con este hasta que se detrya todo el objeto
        gameObject.transform.GetChild(0).gameObject.SetActive(true); // Accede al hijo del objeto uq es el que tiene el efecto visual
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject); // Destruye ambos 
    }
}
