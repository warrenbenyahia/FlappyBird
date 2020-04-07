using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstacle;
    public float spawnTime;
    public float minHeight = -0.45f;
    public float maxHeight = 0.85f;

    [Tooltip("Number of possible y position where obstacles can spawn.")]
    public int spawnNumber = 5;

    private int nObstacle = 1;
    private Vector2 screenBounds;
    private List<float> listPositions = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        float cameraOrtho = Camera.main.orthographicSize;
        screenBounds = new Vector2(Camera.main.aspect * cameraOrtho, cameraOrtho * 2);

        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        float height = Math.Abs(minHeight) + maxHeight;

        float gap = height / (spawnNumber - 1);
        float yPosition = maxHeight;

        for(int i = 0; i < spawnNumber; i++)
        {
            listPositions.Add(yPosition);
            yPosition -= gap;
        }

        StartCoroutine(InstantiateObstacle());
    }

    private IEnumerator InstantiateObstacle()
    {
        while(true)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void SpawnObstacle()
    {
        var obstacleSpawned = GameObject.Instantiate(obstacle);

        obstacleSpawned.name += nObstacle;
        nObstacle++;

        var y = UnityEngine.Random.Range(0, listPositions.Count);
        obstacleSpawned.transform.position = new Vector2((screenBounds.x + 0.3f), listPositions[y]);
    }
}
