using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallB : MonoBehaviour
{
    public Rigidbody2D body;
    private Vector2 startPos = new Vector2(0, 4);

    public Text livesDisplay;
    public int lives = 3;

    public Text gameOverText;
    public Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        // to hide the game over interface when the game is actually going
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        livesDisplay.text = "Lives: " + lives;

        // shoots ball downward when the left mouse button is clicked
        if (Input.GetMouseButtonDown(0)){
            body.velocity = new Vector2(0, -10);
        }

        damage();
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

    void damage()
    {
        // resets position if the ball goes straight past the container and deducts a life
        if (transform.position.y <= -5)
        {
            lives--;
            if (lives > 0)
            {
                resetPosition();
            }
            else
            {
                livesDisplay.gameObject.SetActive(false);

                gameOverText.gameObject.SetActive(true);
                restartButton.gameObject.SetActive(true);
            }
        }
    }
}
