using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float timeElapsed, timeForHold;
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
        if (timeElapsed > timeForHold && buttonDown /* && player.playerVelocity.y > 0 */)
        {
            buttonDown = false;
            player.highJump();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!player.midair) { buttonDown = true; 
            player.jump(); }
        else { player.forwardBurst(); }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonDown = false;
        timeElapsed = 0;
    }
}
