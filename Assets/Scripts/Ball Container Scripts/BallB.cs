using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BallB : MonoBehaviour
{
    // used to reset the ball's position
    private Vector2 startPos;

    // object properties
    public int lives;
    public int level;

    // UI elements
    public Text livesDisplay;
    public Text levelDisplay;
    public Text centralDisplay;
    public Button restartButton;
    public Button pauseButton;
    public ScrollRect levelSelect;

    // for container colour change
    public GameObject container;
    private ContainerA containerScript;
    private IEnumerator colorChange;

    // for ball horizontal movement
    public float horizontalSpeed, speedIncrease, speedLimit;
    private float tempSpeed, initialSpeed;
    private Vector2 direction;

    // for border collision
    private SpriteRenderer rend;
    private Vector2 screenBounds;
    private float objectWidth;

    // for downward velocity
    private Rigidbody2D body;

    // generates obstacles
    public ObstacleInstantiator obstacle;

    // Start is called before the first frame update
    void Start()
    {
        containerScript = container.GetComponent<ContainerA>();

        startPos = transform.position;

        rend = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();

        initialSpeed = horizontalSpeed;

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        objectWidth = rend.bounds.size.x / 2;

        centralDisplay.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        livesDisplay.text = "Lives: " + lives;
        levelDisplay.text = "Level: " + level;

        // shoots ball downward when the left mouse button is clicked

        if (Input.GetMouseButtonDown(0) && body.velocity == new Vector2(0, 0) 
            && !pauseButton.GetComponent<PauseButtonPointerCheck>().pointerEntered 
            && Time.timeScale != 0)
        {
            tempSpeed = horizontalSpeed;
            horizontalSpeed = 0;
            body.velocity = new Vector2(0, -10);   
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

    public void StartGame()
    {
        // to hide the level select + game over interface when the game is actually going
        levelSelect.gameObject.SetActive(false);

        // enable all the things that were invisible with the level select
        levelDisplay.gameObject.SetActive(true);
        livesDisplay.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(true);
        container.SetActive(true);

        LevelSpecificObstacles();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "obstacle")
        {
            level++;
            tempSpeed += speedIncrease;

            // every 5 points the player is given 1 extra life
            if (((level - 1) % 5) == 0) { lives++; }

            LevelSpecificObstacles();

            containerScript.onBallHit();

            resetPosition();

            if (level > 20) { GameOver(); }
        }
        else { damage(); }
        
    }

    private void GameOver()
    {
        // disables the lives and score display, as well as the pause button
        livesDisplay.gameObject.SetActive(false);
        levelDisplay.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);

        // destroys the container object
        containerScript.gameOverDestroy();

        // destroys any obstacles
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("obstacle");
        foreach (GameObject obj in allObjects) { Destroy(obj); }

        // enables the game over text and restart button
        if (lives != 0) { centralDisplay.text = "CONGRATULATIONS! YOU WON!"; }
        centralDisplay.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

        // destroys the ball object
        Destroy(gameObject);
    }

    private void LevelSpecificObstacles()
    {
        // if horizontal movement has been enabled, the ball speed needs to increase with each round
        if (level > 5)
        {
            direction = containerScript.direction * -1;
        }

        if (level > 10 && level <= 15) { obstacle.CreateAllObstacles(level); }

        if (level > 15 && level <= 20)
        {
            foreach (MovingObstacle obstacle in FindObjectsOfType(typeof(MovingObstacle))) { obstacle.startMoving(); }
        }
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
            GameOver();
        }
    }
}
