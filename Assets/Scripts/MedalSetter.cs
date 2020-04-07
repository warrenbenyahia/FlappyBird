using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedalSetter : MonoBehaviour
{
    public Sprite[] medalSprites;

    private Image medalImage;

    // Start is called before the first frame update
    void Start()
    {
        var imageComponent = GetComponent<Image>();

        if (ScoreManager.score < 10)
        {
            imageComponent.enabled = false;
        }
        else if (ScoreManager.score > 9 && ScoreManager.score <20)
        {
            imageComponent.sprite = medalSprites[0];
        }
        else if (ScoreManager.score > 19 && ScoreManager.score < 30)
        {
            imageComponent.sprite = medalSprites[1];
        }
        else if (ScoreManager.score > 29 && ScoreManager.score < 40)
        {
            imageComponent.sprite = medalSprites[2];
        }
        else
        {
            imageComponent.sprite = medalSprites[3];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
