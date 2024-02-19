using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecollectSystem : MonoBehaviour
{
    private int applesCollected;
    public TextMeshProUGUI applesCollectedText; // Asegúrate de importar UnityEngine.UI para poder usar Text

    private void Start()
    {
        applesCollected = 0;
    }

    private void Update()
    {
        if (applesCollected > 10)
        {
            // && TIMER NO A CERO
            Debug.Log($"nivel ganado");
        }
        else if (applesCollected < 10)
        {
            // && TIMER  A CERO
            Debug.Log($"nivel perdido");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            
            Destroy(other.gameObject);
            applesCollected++;
            UpdateApplesUI();
        }
    }


   private void UpdateApplesUI()
   {
     applesCollectedText.text = applesCollected.ToString();
   }

}
