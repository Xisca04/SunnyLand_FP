using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    // HighScore -- BonusLevel

    [SerializeField] private TextMeshProUGUI highScoreText;
    private int highScore;

    private void UpdateHighScoreText()
    {
        highScoreText.text = highScore.ToString();
    }
}
