using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreDisplayer : MonoBehaviour
{
    public GameObject newHighScoreGO;
    public Text bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        var highScore = ScoreManager.GetHighScore();
        bestScoreText.text = highScore.ToString();

        if (ScoreManager.score >= highScore)
        {
            newHighScoreGO.SetActive(true);
        }
    }
}
