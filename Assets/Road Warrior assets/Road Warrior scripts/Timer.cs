using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int timeToComplete, levelTimeIncrease, currentLevelTime;
    private float timeLeft, timeElapsed;
    public bool gameOver = false;
    private GameController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("GameController").GetComponent<GameController>();
        setTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            timeElapsed += Time.deltaTime;
            timeLeft = Mathf.Floor(currentLevelTime - timeElapsed);
            GetComponent<Text>().text = "Time left: " + timeLeft;

            // end game if time has run out
            if (timeLeft <= 0) { controller.timeOver(); }
        }
    }

    public void setTimer()
    {
        currentLevelTime = timeToComplete + (levelTimeIncrease * (controller.level - 1));
        timeElapsed = 0;
    }
}
