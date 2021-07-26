using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    private Button btn;
    private Image img;
    private bool paused = false;
    public Text centralDisplay;
    public Sprite pauseButton, playButton;

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
            centralDisplay.gameObject.SetActive(true);
            centralDisplay.text = "PAUSED";
            img.sprite = playButton;
        }
        else
        {
            Time.timeScale = 1f;
            paused = false;
            centralDisplay.gameObject.SetActive(false);
            img.sprite = pauseButton;
        }
    }
}
