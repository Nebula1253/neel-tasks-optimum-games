using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerA : MonoBehaviour
{
    public float speed;
    public float speedIncrease = (float)1 / 480;
    public float distance;
    private int direction = 1;

    private SpriteRenderer rend;
    private IEnumerator colorChange;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector2(transform.position.x + (speed * direction), transform.position.y);

        // responsible for direction reversal
        if (transform.position.x >= distance || transform.position.x <= -distance) { direction *= -1; }
    }

    // not much point checking WHAT the object is colliding with since there's only one other thing in the scene
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (speed <= 0.025) { speed += speedIncrease; }
        colorChange = colorChangeRoutine(Color.green);
        StartCoroutine(colorChange);
    }

    public IEnumerator colorChangeRoutine(Color colorToChangeTo)
    {
        rend.color = colorToChangeTo;
        yield return new WaitForSeconds(0.5f);
        rend.color = Color.white;
    }
}
