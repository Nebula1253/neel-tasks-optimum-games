using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float speed, speedIncrease;
    private float initSpeed, speedLimit;
    private Vector2 direction;

    private bool isMoving;

    private Vector2 screenBounds;
    private SpriteRenderer rend;
    private float objectWidth;

    // Start is called before the first frame update
    void Start()
    {
        if (Random.value > 0.5f) { direction = Vector2.right; }
        else { direction = Vector2.left; }

        initSpeed = speed;
        speedLimit = initSpeed + 2.5f;

        rend = GetComponent<SpriteRenderer>();

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        objectWidth = rend.bounds.size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving) { transform.Translate(speed * direction * Time.deltaTime); }

        // responsible for direction reversal
        if (transform.position.x >= screenBounds.x - objectWidth) { direction = Vector2.left; }
        else if (transform.position.x <= -screenBounds.x + objectWidth) { direction = Vector2.right; }
    }

    public void startMoving()
    {
        isMoving = true;
        speed += speedIncrease;
        if (speed == speedLimit) { speed = initSpeed; }
    }
}
