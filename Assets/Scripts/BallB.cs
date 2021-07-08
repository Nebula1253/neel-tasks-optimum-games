using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallB : MonoBehaviour
{
    // governs the collision behaviour, as well as the ball's velocity
    public Rigidbody2D body;

    // used to reset the ball's position
    private Vector2 startPos = new Vector2(0, 4);
    
    public Text livesDisplay;
    public int lives;

    public Text gameOverText;
    public Button restartButton;

    public Text scoreDisplay;
    public int score;

    public ContainerA containerScript;
    private IEnumerator colorChange;

    public float horizontalSpeed;
    private float tempSpeed;
    private int direction = 1;

    private SpriteRenderer rend;
    private Vector2 screenBounds;
    private float objectWidth;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        objectWidth = rend.bounds.size.x / 2;

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
            tempSpeed = horizontalSpeed;
            horizontalSpeed = 0;
            body.velocity = new Vector2(0, -10);
        }

        if (score > 5) {
            transform.Translate(Vector2.left * horizontalSpeed * direction * Time.deltaTime);
            // responsible for direction reversal
            if (transform.position.x >= screenBounds.x - objectWidth || transform.position.x <= -screenBounds.x + objectWidth) { direction *= -1; }
        }

        damage();
    }

    // not much point checking WHAT the object is colliding with since there's only one other thing in the scene
    private void OnCollisionEnter2D(Collision2D collision)
    {
        score++;
        // every 5 points the player is given 1 extra life
        if ((score % 5) == 0) { lives++; }

        // if horizontal movement has been enabled, the ball speed needs to increase with each round
        if (score > 5) { tempSpeed++; }

        resetPosition();
    }

    void resetPosition()
    {
        body.velocity = new Vector2(0, 0);
        horizontalSpeed = tempSpeed;
        transform.position = startPos;
    }
    void damage()
    {
        // resets position if the ball goes straight past the container and deducts a life
        if (transform.position.y <= -5) {
            lives--;
            // turns the container red for visual feedback
            colorChange = containerScript.colorChangeRoutine(Color.red);
            StartCoroutine(colorChange);

            if (lives > 0) {
                resetPosition();
            }
            else {
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
