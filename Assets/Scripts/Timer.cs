using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int timeToComplete;
    private bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float timeLeft = (timeToComplete - Mathf.Floor(Time.time));
        GetComponent<Text>().text = "Time left: " + timeLeft;

        if (timeLeft <= 0 && !gameOver) { 
            GameObject.Find("PlayerCar").GetComponent<PlayerCar>().GameOver();
            gameOver = true;
        }
    }
}
