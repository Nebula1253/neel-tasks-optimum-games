using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewScript : MonoBehaviour
{
    // game objects
    public GameObject ball, container;
    public Text levelDisplay, livesDisplay;
    public Button pauseButton;

    // Start is called before the first frame update
    void Start()
    {
        ball.gameObject.SetActive(false);
        container.gameObject.SetActive(false);
        levelDisplay.gameObject.SetActive(false);
        livesDisplay.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
