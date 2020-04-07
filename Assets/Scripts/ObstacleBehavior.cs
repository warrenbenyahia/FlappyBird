using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    public float speed = 2f;
    private float width;

    // Start is called before the first frame update
    void Start()
    {
        width = Camera.main.aspect * Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.right * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        if (gameObject.activeInHierarchy)
            StartCoroutine(ObstacleInvisible());
    }

    private IEnumerator ObstacleInvisible()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            DestroyObstacle();
        }
    }

    private void DestroyObstacle()
    {
        Destroy(gameObject);
    }
}
