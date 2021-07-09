using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerA : MonoBehaviour
{
    public float speed, speedLimit, speedIncrease; 
    private float initialSpeed;
    public Vector2 direction = Vector2.right;

    private SpriteRenderer rend;
    private IEnumerator colorChange;

    private Vector2 screenBounds;
    private float objectWidth;

    // Start is called before the first frame update
    void Start()
    {
        initialSpeed = speed;
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

    public void onBallHit()
    {
        if (speed < speedLimit) { speed += speedIncrease; }
        if (speed == speedLimit) { speed = initialSpeed; }
        colorChange = colorChangeRoutine(Color.green);
        StartCoroutine(colorChange);
    }

    // used to change the colour of the container when the ball hits/misses it
    public IEnumerator colorChangeRoutine(Color colorToChangeTo)
    {
        rend.color = colorToChangeTo;
        yield return new WaitForSeconds(0.5f);
        rend.color = Color.white;
    }
}
