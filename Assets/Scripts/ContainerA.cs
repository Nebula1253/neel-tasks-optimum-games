using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerA : MonoBehaviour
{
    public float speed;
    public float speedIncrease = (float)1 / 480;
    private int direction = 1;

    private SpriteRenderer rend;
    private IEnumerator colorChange;

    private Vector2 screenBounds;
    private float objectWidth;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        objectWidth = rend.bounds.size.x / 2;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * direction * Time.deltaTime);

        // responsible for direction reversal
        if (transform.position.x >= screenBounds.x - objectWidth || transform.position.x <= -screenBounds.x + objectWidth) { direction *= -1; }
    }

    // not much point checking WHAT the object is colliding with since there's only one other thing in the scene
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (speed <= 10) { speed += speedIncrease; }
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
