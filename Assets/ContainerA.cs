using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerA : MonoBehaviour
{
    public float speed;
    public float speedIncrease = (float)1 / 480;
    private int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector2(transform.position.x + (speed * direction), transform.position.y);

        // responsible for direction reversal
        if (transform.position.x >= 10.5 || transform.position.x <= -10.5) { direction *= -1; }
    }

    // not much point checking WHAT the object is colliding with since there's only one other thing in the scene
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (speed == 0.025) { speed += speedIncrease; }
    }
}
