using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PickCollectables : MonoBehaviour
{
    // Player pick collectables

    private Score _score;

    private void Awake()
    {
        _score = GetComponent<Score>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gem"))
        {
            Debug.Log("Gem picked");
            Destroy(other.gameObject);
            _score.AddScore(Score.GEM_SCORE);
        }

        if (other.CompareTag("Cherry"))
        {
            Debug.Log("Cherry picked");
            Destroy(other.gameObject);
            _score.AddScore(Score.CHERRY_SCORE);
        }
    }
}
