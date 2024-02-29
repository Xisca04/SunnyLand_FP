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

    public const string HIGH_SCORE = "highScore"; // Clave en PlayerPrefs

    public static event EventHandler OnHighScoreChange; // Event


    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE, 0);
    }

    public static bool TrySetNewHighScore() // score = current puntuation
    {
        int highScore = GetHighScore();

        if (score > highScore)
        {
            // Modificamos el High Score
            PlayerPrefs.SetInt(HIGH_SCORE, score);
            PlayerPrefs.Save();

            if (OnHighScoreChange != null)
            {
                OnHighScoreChange(null, EventArgs.Empty);
            }

            return true;
        }

        return false;
    }

    public static void InitializeStaticScore()
    {
        OnHighScoreChange = null;
        score = 0;
        AddScore(0);
        ScoreUI.Instance.UpdateHighScoreText();
    }

    public static int GetScore()
    {
        return score;
    }
}
