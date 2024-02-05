using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PU_CountdownCollectable : MonoBehaviour
{
    // Detección player --> destroy este game object --> aparecen gemas --> al pasar 5 segundos desaparecen
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private GameObject gems;
    private float colorTransparency = 0.05f;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        gems.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Material material = _spriteRenderer.material;
            Color color = material.color;
            color.a = colorTransparency;
            material.color = color;
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
