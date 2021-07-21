using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int timeToComplete;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            float timeLeft = timeToComplete - Mathf.Floor(Time.time);
            GetComponent<Text>().text = "Time left: " + timeLeft;

            // end game if time has run out
            if (timeLeft <= 0)
            {
                GameObject.Find("PlayerCar").GetComponent<PlayerCar>().timeOver();
            }
        }
    }
}
