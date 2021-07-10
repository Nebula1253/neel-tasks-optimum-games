using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleInstantiator : MonoBehaviour
{
    public GameObject staticObstacle;
    public GameObject movingObstacle;

    private Vector2 screenBounds;
    private SpriteRenderer rend;
    private float screenBorder;
    private float[] spawnPositions = new float[5];
    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        rend = staticObstacle.GetComponent<SpriteRenderer>();
        screenBorder = screenBounds.x - (rend.bounds.size.x / 2);

        // populate spawn positions array
        spawnPositions[0] = 0;
        spawnPositions[1] = screenBorder;
        spawnPositions[2] = -1 * screenBorder;
        spawnPositions[3] = screenBorder / 2;
        spawnPositions[4] = screenBorder / -2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateObstacle()
    {
        if (currentIndex <= 2) { Instantiate(staticObstacle, new Vector2(spawnPositions[currentIndex], 0), Quaternion.identity); }
        else { Instantiate(movingObstacle, new Vector2(spawnPositions[currentIndex], 0), Quaternion.identity); }
        currentIndex++;
    }
}
