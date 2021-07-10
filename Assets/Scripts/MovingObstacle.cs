using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float setSpeed, speedIncrease;
    private float speed;
    private Vector2 direction = Vector2.left;

    private Vector2 screenBounds;
    private SpriteRenderer rend;
    private float objectWidth;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0;

        rend = GetComponent<SpriteRenderer>();

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        objectWidth = rend.bounds.size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * direction * Time.deltaTime);

        // responsible for direction reversal
        if (transform.position.x >= screenBounds.x - objectWidth) { direction = Vector2.left; }
        else if (transform.position.x <= -screenBounds.x + objectWidth) { direction = Vector2.right; }
    }

    public void startMoving()
    {
        speed = setSpeed;
        setSpeed += speedIncrease;
    }
}
