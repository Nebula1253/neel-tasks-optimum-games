using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    private Text text;
    private ControllerPlatformer controller;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        controller = GameObject.Find("GameController").GetComponent<ControllerPlatformer>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "HP: " + controller.playerHP;
    }
}
