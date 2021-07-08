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
    
    // player life count + UI element
    public Text livesDisplay;
    public int lives;

    // UI elements for game over
    public Text gameOverText;
    public Button restartButton;

    // player score + UI element
    public Text scoreDisplay;
    public int score;

    // so that the container turns red when the ball misses
    public ContainerA containerScript;
    private IEnumerator colorChange;

    // for horizontal movement past score 5
    public float horizontalSpeed;
    private float tempSpeed;
    private Vector2 direction = Vector2.left;

    // for dynamic movement boundaries
    private SpriteRenderer rend;
    private Vector2 screenBounds;
    private float objectWidth;

    public ObstacleInstantiator obstacle;

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
        if (body.velocity == new Vector2(0,0)) {
            if (Input.GetMouseButtonDown(0)) {
                tempSpeed = horizontalSpeed;
                horizontalSpeed = 0;
                body.velocity = new Vector2(0, -10);
            }
        }

        if (score > 5) {
            transform.Translate(horizontalSpeed * direction * Time.deltaTime);

            // responsible for direction reversal
            if (transform.position.x >= screenBounds.x - objectWidth) { direction = Vector2.left; }
            else if (transform.position.x <= -screenBounds.x + objectWidth) { direction = Vector2.right; }
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

        if (score > 10 && score <= 15) { obstacle.CreateObstacle(screenBounds.x, -screenBounds.x); }

        resetPosition();
    }

    void resetPosition()
    {
        horizontalSpeed = tempSpeed;
        transform.position = startPos;
        body.velocity = new Vector2(0, 0);
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
