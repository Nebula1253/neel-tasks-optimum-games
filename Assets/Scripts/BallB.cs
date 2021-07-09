using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallB : MonoBehaviour
{
    // used to reset the ball's position
    private Vector2 startPos;
    
    // player life count + UI element
    public Text livesDisplay;
    public int lives;

    // UI elements for game over
    public Text gameOverText;
    public Button restartButton;

    // player score + UI element
    public Text levelDisplay;
    public int level;

    public ContainerA containerScript;

    // so that the container turns red when the ball misses
    private IEnumerator colorChange;

    // for horizontal movement past score 5
    public float horizontalSpeed, speedIncrease, speedLimit;
    private float tempSpeed, initialSpeed;
    private Vector2 direction;

    // for dynamic movement boundaries
    private SpriteRenderer rend;
    private Vector2 screenBounds;
    private float objectWidth;

    // for downward velocity
    private Rigidbody2D body;

    public ObstacleInstantiator obstacle;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;

        rend = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();

        initialSpeed = horizontalSpeed;

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
        levelDisplay.text = "Level: " + level;

        // shoots ball downward when the left mouse button is clicked
        if (body.velocity == new Vector2(0,0))
        {
            if (Input.GetMouseButtonDown(0))
            {
                tempSpeed = horizontalSpeed;
                horizontalSpeed = 0;
                body.velocity = new Vector2(0, -10);
            }
        }

        if (level > 5) {
            transform.Translate(horizontalSpeed * direction * Time.deltaTime);

            // responsible for direction reversal
            if (transform.position.x >= screenBounds.x - objectWidth) { direction = Vector2.left; }
            else if (transform.position.x <= -screenBounds.x + objectWidth) { direction = Vector2.right; }
        }

        if (horizontalSpeed == speedLimit) { horizontalSpeed = initialSpeed; }

        if (transform.position.y < -screenBounds.y) { damage(); }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "obstacle")
        {
            level++;
            tempSpeed += speedIncrease;

            // every 5 points the player is given 1 extra life
            if ((level % 5) == 0) { lives++; }

            // if horizontal movement has been enabled, the ball speed needs to increase with each round
            if (level > 5)
            {
                direction = containerScript.direction * -1;
            }

            if (level > 10 && level <= 15) { obstacle.CreateObstacle(); }

            containerScript.onBallHit();

            resetPosition();
        }
        else { damage(); }
        
    }

    void resetPosition()
    {
        horizontalSpeed = tempSpeed;
        transform.position = startPos;
        body.velocity = new Vector2(0,0);
    }
    void damage()
    {
        // resets position if the ball goes straight past the container and deducts a life
        lives--;

        if (lives > 0) {
            resetPosition();
            // turns the container red for visual feedback
            colorChange = containerScript.colorChangeRoutine(Color.red);
            StartCoroutine(colorChange);
        }
        else {
            // disables the lives and score display
            livesDisplay.gameObject.SetActive(false);
            levelDisplay.gameObject.SetActive(false);

            // destroys the container object
            containerScript.gameOverDestroy();

            // destroys any obstacles
            GameObject[] allObjects = GameObject.FindGameObjectsWithTag("obstacle");
            foreach(GameObject obj in allObjects) { Destroy(obj); }

            // enables the game over text and restart button
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);

            // destroys the ball object
            Destroy(gameObject);
        }
    }
}
