using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    private Button btn;
    private Image img;
    private bool paused = false;
    public Sprite pauseButton, playButton;
    // UI elements to enable / disable
    public Text centralDisplay;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        btn = GetComponent<Button>();
        img.sprite = pauseButton;
        btn.onClick.AddListener(onPauseButtonClick);
    }

    void onPauseButtonClick()
    {
        if (!paused)
        {
            Time.timeScale = 0f;
            paused = true;
            img.sprite = playButton;

            centralDisplay.gameObject.SetActive(true);
            centralDisplay.text = "PAUSED";
        }
        else
        {
            Time.timeScale = 1f;
            paused = false;
            img.sprite = pauseButton;

            centralDisplay.gameObject.SetActive(false);
        }
    }
}
