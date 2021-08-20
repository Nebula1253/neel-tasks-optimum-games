using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float timeElapsed;
    private bool buttonDown;
    private PlatformerPlayer player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlatformerPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonDown) { timeElapsed += Time.deltaTime; }
        if (timeElapsed > 0.2f && buttonDown)
        {
            buttonDown = false;
            player.jumpButtonPress();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonDown = true;
        if (!player.midair) { player.jumpButtonPress(); }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonDown = false;
        timeElapsed = 0;
    }
}
