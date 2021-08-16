using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private PlatformerPlayer player;
    private bool jump = false;
    private float timeElapsed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlatformerPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jump) { timeElapsed += Time.deltaTime; }
    }

    public void OnPointerDown(PointerEventData eventData) { jump = true; }

    public void OnPointerUp(PointerEventData eventData) { 
        jump = false;
        if (timeElapsed > 0.5) { player.jumpButtonHold(); }
        else { player.jumpButtonPress(); }
        timeElapsed = 0;
    }
}
