using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PU_CountdownCollectable : MonoBehaviour
{
    // Detección player --> destroy este game object --> aparecen gemas --> al pasar 5 segundos desaparecen
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private GameObject gems;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        gems.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _spriteRenderer.color = new Color(0, 0, 0);
            StartCoroutine("CountdownGems");
        }
    }

    private IEnumerator CountdownGems()
    {
        gems.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);
    }
}
