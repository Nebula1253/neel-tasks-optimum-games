using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewScript : MonoBehaviour
{
    // game objects
    public GameObject ball, container;
    public Text levelDisplay, livesDisplay, gameOverText;
    public Button pauseButton, restartButton;

    // Start is called before the first frame update
    void Start()
    {
        ball.SetActive(false);
        container.SetActive(false);
        levelDisplay.gameObject.SetActive(false);
        livesDisplay.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
