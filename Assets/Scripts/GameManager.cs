using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject scoreCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
        ScoreManager.score = 0;
    }

    public void GameOver()
    {
        SoundManager.PlaySound((int)Constants.SoundsIndex.Hit);

        var highScore = PlayerPrefs.GetInt(Constants.HIGHSCORE, 0);

        if (ScoreManager.score > highScore)
            PlayerPrefs.SetInt(Constants.HIGHSCORE, ScoreManager.score);

        scoreCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }
}
