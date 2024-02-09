using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PickCollectables : MonoBehaviour
{
    // Player pick collectables

    private Score _score;
    //[SerializeField] private GameObject _feedbackGem;

    private void Awake()
    {
        _score = GetComponent<Score>();
        //_feedbackGem.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gem"))
        {
            Debug.Log("Gem picked");
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(other.gameObject);
            // StartCoroutine("StartFeedbackVFX"); // HACER QUE EL PREFAB DE LOS ITEMS TENGA EL VFX Y ACCEDER A ESTE CO IN CHILDREN PARA NO TENER QUE ASIGNAR CADA VFX

            _score.AddScore(Score.GEM_SCORE);
        }

        if (other.CompareTag("Cherry"))
        {
            Debug.Log("Cherry picked");
            Destroy(other.gameObject);
            _score.AddScore(Score.CHERRY_SCORE);
        }
    }
    /*
    private IEnumerator StartFeedbackVFX()
    {
       other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
       // yield return new WaitForSeconds(0.3f);
        //_feedbackGem.SetActive(false);
    }
    */
}
