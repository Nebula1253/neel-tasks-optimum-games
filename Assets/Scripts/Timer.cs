using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int timeToComplete, levelTimeIncrease;
    private float timeLeft, timeElapsed;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = timeToComplete;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            timeElapsed += Time.deltaTime;
            timeLeft = Mathf.Floor(timeToComplete - timeElapsed);
            GetComponent<Text>().text = "Time left: " + timeLeft;

            // end game if time has run out
            if (timeLeft <= 0)
            {
                GameObject.Find("PlayerCar").GetComponent<PlayerCar>().timeOver();
            }
        }
    }

    public void resetTimer()
    {
        timeToComplete += levelTimeIncrease;
        timeElapsed = 0;
    }
}
