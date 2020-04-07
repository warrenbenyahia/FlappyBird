using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCollision : MonoBehaviour
{
    public GameObject pipe;
    public GameObject ground;
    public GameManager gameManager;
    public GameObject scoreTrigger;

    private Vector2 screenBounds;

    private void Start()
    {
        float cameraOrtho = Camera.main.orthographicSize;
        screenBounds = new Vector2(Camera.main.aspect * cameraOrtho, cameraOrtho * 2);
    }

    private void Update()
    {
        if (transform.position.y > (screenBounds.y / 2))
        {
            gameManager.GameOver();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == scoreTrigger.tag)
        {
            ScoreManager.score++;
            SoundManager.PlaySound((int)Constants.SoundsIndex.Point);
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(pipe.tag) || collision.gameObject.CompareTag(ground.tag))
        {
            gameManager.GameOver();
        }
    }
}
