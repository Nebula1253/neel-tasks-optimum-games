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

    public Text scoreDisplay;
    public int score = 0;

    public ContainerA containerScript;
    private IEnumerator colorChange;

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
        scoreDisplay.text = "Score: " + score;

        // shoots ball downward when the left mouse button is clicked
        if (Input.GetMouseButtonDown(0)){
            body.velocity = new Vector2(0, -10);
        }

        damage();
    }

    // not much point checking WHAT the object is colliding with since there's only one other thing in the scene
    private void OnCollisionEnter2D(Collision2D collision)
    {
        score++;
        if ((score % 5) == 0) { lives++; }
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
            // turns the container red for visual feedback
            colorChange = containerScript.colorChangeRoutine(Color.red);
            StartCoroutine(colorChange);

            if (lives > 0)
            {
                resetPosition();
            }
            else
            {
                // disables the lives and score display
                livesDisplay.gameObject.SetActive(false);
                scoreDisplay.gameObject.SetActive(false);

                // enables the game over text and restart button
                gameOverText.gameObject.SetActive(true);
                restartButton.gameObject.SetActive(true);

                // destroys the ball object to save memory
                Destroy(this);
            }
        }
    }
}
