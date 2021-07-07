using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallB : MonoBehaviour
{
    public Rigidbody2D body;
    private Vector2 startPos = new Vector2(0, 4);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // shoots ball downward when the left mouse button is clicked
        if (Input.GetMouseButtonDown(0)){
            body.velocity = new Vector2(0, -10);
        }

        // resets position if the ball goes straight past the container
        if (transform.position.y <= -5)
        {
            resetPosition();
        }
    }

    // not much point checking WHAT the object is colliding with since there's only one other thing in the scene
    private void OnCollisionEnter2D(Collision2D collision)
    {
        resetPosition();
    }

    void resetPosition()
    {
        body.velocity = new Vector2(0, 0);
        transform.position = startPos;
    }
}
