using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager
{
    public static int score = 0;

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(Constants.HIGHSCORE, 0);
    }

    public static void SetHighScore(int highScore)
    {
        PlayerPrefs.SetInt(Constants.HIGHSCORE, highScore);
    }
}
